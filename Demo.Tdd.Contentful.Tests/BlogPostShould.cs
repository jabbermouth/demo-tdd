namespace Demo.Tdd.Contentful.Tests;

public class BlogPostShould
{
	[Fact]
	public async void ReturnAnEmptyListWhenNoBlogsExist()
	{
		// Arrange
		IHttpClientFactory httpClientFactory = MockFactories.GetStringClient(Constants.RESULT_LIST_EMPTY);
		var sut = new BlogPost(httpClientFactory);

		// Act
		var results = await sut.ListAsync();

		// Assert
		results.Should().NotBeNull();
		results.Should().BeEmpty();
	}
}
