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

	[Fact]
	public void ListMostRecentBlogs()
	{
		// Arrange
		IEnumerable<BlogPostEntry> blogPostEntries = new List<BlogPostEntry>() { new BlogPostEntry() { Title = "Test blog article", Summary = "A bit of blurb with some __bold__ text." } };
		Mock<IBlogPost> blogPost = new();
		blogPost.Setup(method => method.ListAsync()).Returns(Task.FromResult(blogPostEntries));

		Services.AddSingleton<IBlogPost>(blogPost.Object);
		var cut = RenderComponent<BlogList>();

		// Act
		cut.WaitForState(() => cut.Find("ul") is not null);

		// Assert
		var ul = cut.Find("ul");
		ul.Children[0].MarkupMatches("<li><b>Test blog article</b><p>A bit of blurb with some <strong>bold</strong> text.</p></li>");
	}
}
