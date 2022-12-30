using Demo.Tdd.Contentful;
using Demo.Tdd.Contentful.Models;
using Demo.Tdd.Ui.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Tdd.Ui.Tests;

public class BlogListShould : TestContext
{
	[Fact]
	public void ShowNoBlogsFoundOnEmptyList()
	{
		// Arrange
		IEnumerable<BlogPostEntry> blogPostEntries = new List<BlogPostEntry>();
		Mock<IBlogPost> blogPost = new();
		blogPost.Setup(method => method.ListAsync()).Returns(Task.FromResult(blogPostEntries));

		Services.AddSingleton<IBlogPost>(blogPost.Object);
		var cut = RenderComponent<BlogList>();

		// Act

		// Assert
		cut.Find("p").MarkupMatches("<p>There are no blogs to display.</p>");
	}
}
