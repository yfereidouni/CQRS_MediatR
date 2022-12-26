using AutoFixture;
using CQRS_MediatR.Model.Framework;
using CQRS_MediatR.Model.Tags.Commands;
using CQRS_MediatR.Model.Tags.Entities;
using CQRS_MediatR.WebAPI.Tags;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CQRS_MediatR.WebAPI.Tests.Tags
{
    [TestClass]
    public class TagsControllerTests
    {
        private Mock<IMediator> _mediatorMock;

        private Fixture _fixture;
        private TagsController _tagsController;

        public TagsControllerTests()
        {
            _fixture = new Fixture();
            _mediatorMock = new Mock<IMediator>();

            _tagsController = new TagsController(_mediatorMock.Object);
        }

        [TestMethod]
        public async Task CreateTag_Returns_Ok()
        {
            var tag = _fixture.Create<CreateTag>();
            var response = _fixture.Create<Task<ApplicationServiceResponse<Tag>>>();

            await _tagsController.CreateTag(tag);


            var obj = new OkObjectResult(response);

            Assert.AreEqual(200, obj.StatusCode);
        }
    }
}