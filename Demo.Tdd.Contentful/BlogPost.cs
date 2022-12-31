using Demo.Tdd.Contentful.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace Demo.Tdd.Contentful;

public class BlogPost : IBlogPost
{
	private readonly HttpClient _httpClient;
	private readonly ContentfulConfig _config;

	public BlogPost(IHttpClientFactory httpClientFactory, IOptions<ContentfulConfig> config)
	{
		_config = config.Value;
		_httpClient = httpClientFactory.CreateClient();
		_httpClient.BaseAddress = new Uri(_config.BaseUrl ?? "");
	}

	public async Task<IEnumerable<BlogPostEntry>> ListAsync()
	{
		string? posts = null;

		try
		{
			posts = await _httpClient.GetStringAsync($"/spaces/{_config.SpaceId}/environments/{_config.Environment}/entries?access_token={_config.ApiKeys?.PublishedContent}");
		} 
		catch
		{
			return new List<BlogPostEntry>();
		}

		var response = JsonSerializer.Deserialize<ContentfulResponse>(posts);

		if (response is null || response.items is null || !response.items.Any())
		{
			return new List<BlogPostEntry>();
		}

		List<BlogPostEntry> blogPosts = new();

		foreach (var blogPostEntry in response.items)
		{
			var fields = (JsonElement)blogPostEntry["fields"];

			blogPosts.Add(new BlogPostEntry()
			{
				Title = fields.GetProperty("title").GetString() ?? "",
				Summary = fields.GetProperty("summary").GetString() ?? "",
				Article = fields.GetProperty("article").GetString() ?? ""
			});
		}

		return blogPosts;
	}
}
