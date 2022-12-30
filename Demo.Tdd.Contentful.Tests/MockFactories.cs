using Moq;
using Moq.Protected;
using System.Net;

namespace Demo.Tdd.Contentful.Tests;

public static class MockFactories
{
	public static IHttpClientFactory GetStringClient(string returnValue)
	{
		Mock<HttpMessageHandler> httpMessageHandler = new();
		Mock<IHttpClientFactory> httpClientFactory = new();

		httpMessageHandler.Protected().Setup<Task<HttpResponseMessage>>(
				"SendAsync",
				ItExpr.IsAny<HttpRequestMessage>(),
				ItExpr.IsAny<CancellationToken>()
			)
			.ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(returnValue) });

		HttpClient httpClient = new(httpMessageHandler.Object);
		httpClientFactory.Setup(factory => factory.CreateClient(It.IsAny<string>())).Returns(httpClient);

		return httpClientFactory.Object;
	}
}
