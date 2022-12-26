using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.MediatR.BLL.Framework;
using CQRS.MediatR.DAL.ApplicationDB;
using CQRS.MediatR.DAL.Tags;
using CQRS.MediatR.Model.Tags.DTOs;
using CQRS.MediatR.Model.Tags.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.MediatR.BLL.Tags.Queries
{
    public class FilterByNameHandler : BaseApplicationServiceHandler<FilterByName, List<TagQr>>
    {
        public FilterByNameHandler(ApplicationDbContext courseStoreDbContext) 
            : base(courseStoreDbContext) { }

        protected override async Task HandleRequest(FilterByName request, CancellationToken cancellationToken)
        {
            var result = await _courseStoreDbContext.Tags.WhereOver(request.TagName).ToTagQrAsync();

            AddResult(result);
        }
    }
}
