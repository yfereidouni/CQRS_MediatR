using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS_MediatR.BLL.Framework;
using CQRS_MediatR.DAL.ApplicationDB;
using CQRS_MediatR.Model.Framework;
using CQRS_MediatR.Model.Tags.Commands;
using CQRS_MediatR.Model.Tags.Entities;
using MediatR;

namespace CQRS_MediatR.BLL.Tags.Commands
{
    public class CreateTagHandler : BaseApplicationServiceHandler<CreateTag, Tag>
    {
        public CreateTagHandler(ApplicationDbContext courseStoreDbContext) 
            : base(courseStoreDbContext) { }

        protected override async Task HandleRequest(CreateTag request, CancellationToken cancellationToken)
        {
            Tag tag = new Tag
            {
                TagName = request.TagName
            };

            await _courseStoreDbContext.Tags.AddAsync(tag);
            await _courseStoreDbContext.SaveChangesAsync();

            AddResult(tag);
        }
    }
}
