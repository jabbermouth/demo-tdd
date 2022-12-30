using Demo.Tdd.Contentful.Models;
using Microsoft.Extensions.Options;

namespace Demo.Tdd.Contentful.Tests;

public static class Constants
{
	public const string RESULT_LIST_EMPTY = """
    {
        "sys": {
        "type": "Array"
        },
        "total": 0,
        "skip": 0,
        "limit": 100,
        "items": []
    }
    """;

	public const string RESULT_LIST_POPULATED_TWO = """
    {
        "sys": {
        "type": "Array"
        },
        "total": 2,
        "skip": 0,
        "limit": 100,
        "items": [
        {
            "metadata": {
            "tags": []
            },
            "sys": {
            "space": {
                "sys": {
                "type": "Link",
                "linkType": "Space",
                "id": "b27mtzlwgnec"
                }
            },
            "id": "1dP03LAJlww9kikCDLFTXL",
            "type": "Entry",
            "createdAt": "2022-12-26T16:41:06.408Z",
            "updatedAt": "2022-12-26T17:08:57.292Z",
            "environment": {
                "sys": {
                "id": "production",
                "type": "Link",
                "linkType": "Environment"
                }
            },
            "revision": 2,
            "contentType": {
                "sys": {
                "type": "Link",
                "linkType": "ContentType",
                "id": "blogArticle"
                }
            },
            "locale": "en-US"
            },
            "fields": {
            "title": "Test blog article",
            "summary": "This is my __test__ blog article summary.",
            "article": "This is the body __with bold__ of my article."
            }
        },
        {
            "metadata": {
            "tags": []
            },
            "sys": {
            "space": {
                "sys": {
                "type": "Link",
                "linkType": "Space",
                "id": "b27mtzlwgnec"
                }
            },
            "id": "2dP03LAJlww9kikMBLBNPQ",
            "type": "Entry",
            "createdAt": "2022-12-27T16:41:06.408Z",
            "updatedAt": "2022-12-27T17:08:57.292Z",
            "environment": {
                "sys": {
                "id": "production",
                "type": "Link",
                "linkType": "Environment"
                }
            },
            "revision": 2,
            "contentType": {
                "sys": {
                "type": "Link",
                "linkType": "ContentType",
                "id": "blogArticle"
                }
            },
            "locale": "en-US"
            },
            "fields": {
            "title": "Another test blog article",
            "summary": "This is my __second__ blog article summary.",
            "article": "This body __also has bold__ in my article."
            }
        }
        ]
    }
    """;

	public static IOptions<ContentfulConfig> GetContentfulConfig()
	{
		ContentfulConfig contentfulConfig = new()
		{
			BaseUrl = "https://api.baseurl.com",
			SpaceId = "SPACE-ID",
			Environment = "ENVIRONMENT",
			ApiKeys = new ContentfulConfigApiKeys() { PublishedContent = "MY-ACCESS-TOKEN" }
		};

		return Options.Create(contentfulConfig);
	}
}
