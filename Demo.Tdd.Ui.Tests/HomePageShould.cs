using Demo.Tdd.Contentful;
using Demo.Tdd.Ui.Shared;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Tdd.Ui.Tests;

public class HomePageShould : TestContext
{
    [Fact]
    public void IncludeBlogListComponent()
    {
        // Arrange
        Mock<IBlogPost> blogPost = new();
        Services.AddSingleton<IBlogPost>(blogPost.Object);
        var put = RenderComponent<Pages.Index>();

        // Act

        // Assert
        Assert.True(put.HasComponent<BlogList>());
    }
}
