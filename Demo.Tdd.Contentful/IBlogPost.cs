using Demo.Tdd.Contentful.Models;

namespace Demo.Tdd.Contentful;

public interface IBlogPost
{
	Task<IEnumerable<BlogPostEntry>> ListAsync();
}