namespace Demo.Tdd.Contentful.Models;

internal class ContentfulResponse
{
	public int total { get; set; }
	public List<Dictionary<string, object>>? items { get; set; }
}
