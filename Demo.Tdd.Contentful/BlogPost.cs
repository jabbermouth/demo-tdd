using Demo.Tdd.Contentful.Models;

namespace Demo.Tdd.Contentful;

public class BlogPost
{
	public BlogPost(IHttpClientFactory httpClientFactory)
	{

	}

	public async Task<IEnumerable<BlogPostEntry>> ListAsync()
	{
		throw new NotImplementedException();
	}
}
