﻿using CQRS.MediatR.BLL.Framework;
using CQRS.MediatR.DAL.ApplicationDB;
using CQRS.MediatR.Model.Tags.Commands;
using CQRS.MediatR.Model.Tags.Entities;

namespace CQRS.MediatR.BLL.Tags.Commands;

public class UpdateTagHandler : BaseApplicationServiceHandler<UpdateTag, Tag>
{
    public UpdateTagHandler(ApplicationDbContext courseStoreDbContext)
        : base(courseStoreDbContext)
    {
    }

    protected override async Task HandleRequest(UpdateTag request, CancellationToken cancellationToken)
    {
        Tag tag = _courseStoreDbContext.Tags.SingleOrDefault(c => c.Id == request.Id);
        if (tag == null)
        {
            AddError($"Tag with id {request.Id} was not found!");
        }
        else
        {
            tag.TagName = request.TagName;
            await _courseStoreDbContext.SaveChangesAsync();
            AddResult(tag);
        }
    }

}