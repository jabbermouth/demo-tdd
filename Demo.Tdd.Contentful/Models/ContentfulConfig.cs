namespace Demo.Tdd.Contentful.Models;

public class ContentfulConfig
{
	public string? BaseUrl { get; set; }
	public string? SpaceId { get; set; }
	public string? Environment { get; set; }
	public ContentfulConfigApiKeys? ApiKeys { get; set; }
}

public class ContentfulConfigApiKeys
{
	public string? PublishedContent { get; set; }
	public string? PreviewContent { get; set; }
}