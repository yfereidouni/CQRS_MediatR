using CQRS.MediatR.Model.Framework;
using CQRS.MediatR.Model.Tags.DTOs;
using MediatR;

namespace CQRS.MediatR.Model.Tags.Queries
{
    public class FilterByName : IRequest<ApplicationServiceResponse<List<TagQr>>>
    {
        public string? TagName { get; set; }
    }
}
