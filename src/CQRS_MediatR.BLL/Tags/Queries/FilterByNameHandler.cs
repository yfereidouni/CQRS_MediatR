using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS_MediatR.BLL.Framework;
using CQRS_MediatR.DAL.ApplicationDB;
using CQRS_MediatR.DAL.Tags;
using CQRS_MediatR.Model.Tags.DTOs;
using CQRS_MediatR.Model.Tags.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_MediatR.BLL.Tags.Queries
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
