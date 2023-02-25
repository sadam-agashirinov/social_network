using System;
using System.Threading;
using System.Threading.Tasks;
using Application.UseCases.Post.Commands.CreatePost;
using ApplicationIntegrationTests.Common;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace ApplicationIntegrationTests.Post.Commands;

public class CreatePostHandlerTests : BaseTest
{
    [Test]
    public async Task CreateCustomer_Success()
    {
        //arrange
        var sut = new CreatePostCommandHandler(DbContext);
        var requestData = new CreatePostCommand()
        {
            Post = "This is new post.",
            BloggerId = Guid.NewGuid()
        };
        
        //act
        var postId = await sut.Handle(requestData, CancellationToken.None);

        //assert
        var postFromEntity = await DbContext.Posts.SingleOrDefaultAsync(x => x.Id == postId);

        postFromEntity.Should().NotBeNull();
        postFromEntity.Id.Should().Be(postId);
        postFromEntity.Text.Should().Be(requestData.Post);
        postFromEntity.BloggerId.Should().Be(requestData.BloggerId);
        postFromEntity.Created.Should().NotBe(DateTime.MinValue);
    }
}