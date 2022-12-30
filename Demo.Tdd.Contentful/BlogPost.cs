using Demo.Tdd.Contentful.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Demo.Tdd.Contentful;

public class BlogPost
{
	private readonly HttpClient _httpClient;

	public BlogPost(IHttpClientFactory httpClientFactory, IOptions<ContentfulConfig> config)
	{
		_httpClient = httpClientFactory.CreateClient();
		_httpClient.BaseAddress = new Uri("https://cdn.contentful.com");
	}

	public async Task<IEnumerable<BlogPostEntry>> ListAsync()
	{
		string? posts = await _httpClient.GetStringAsync("/spaces/b27mtzlwgnec/environments/production/entries?access_token=dskuhg87hguogj487g84gkh");

		var response = JsonSerializer.Deserialize<ContentfulResponse>(posts);

		if (response is null || response.items is null || !response.items.Any())
		{
			return new List<BlogPostEntry>();
		}

		List<BlogPostEntry> blogPosts = new();

		foreach (var blogPostEntry in response.items)
		{
			blogPosts.Add(new BlogPostEntry());
		}

		return blogPosts;
	}
}
