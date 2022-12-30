using Moq.Protected;
using Moq;

namespace Demo.Tdd.Contentful.Tests;

public class BlogPostShould
{
	[Fact]
	public async void ReturnAnEmptyListWhenNoBlogsExist()
	{
		// Arrange
		IHttpClientFactory httpClientFactory = MockFactories.GetStringClient(Constants.RESULT_LIST_EMPTY);
		var sut = new BlogPost(httpClientFactory, Constants.GetContentfulConfig());

		// Act
		var results = await sut.ListAsync();

		// Assert
		results.Should().NotBeNull();
		results.Should().BeEmpty();
	}

	[Fact]
	public async void ReturnAListOfBlogs()
	{
		// Arrange
		IHttpClientFactory httpClientFactory = MockFactories.GetStringClient(Constants.RESULT_LIST_POPULATED_TWO);
		var sut = new BlogPost(httpClientFactory, Constants.GetContentfulConfig());

		// Act
		var results = await sut.ListAsync();

		// Assert
		results.Should().NotBeNullOrEmpty();
		results.Should().HaveCount(2);
	}

	[Fact]
	public async void ReadValuesFromConfigurationToCallAPI()
	{
		// Arrange
		Mock<HttpMessageHandler> httpMessageHandler;
		IHttpClientFactory httpClientFactory = MockFactories.GetMockMessageHandler(Constants.RESULT_LIST_EMPTY, out httpMessageHandler);
		var sut = new BlogPost(httpClientFactory, Constants.GetContentfulConfig());
		string expectedQueryList = "https://api.baseurl.com/spaces/SPACE-ID/environments/ENVIRONMENT/entries?access_token=MY-ACCESS-TOKEN";

		// Act
		await sut.ListAsync();

		// Assert
		httpMessageHandler.Protected().Verify(
			"SendAsync",
			Times.Once(),
			ItExpr.Is<HttpRequestMessage>(entry => entry.RequestUri.AbsoluteUri == expectedQueryList),
			ItExpr.IsAny<CancellationToken>()
			);
	}
}
