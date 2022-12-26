using CQRS_MediatR.Model.Framework;
using CQRS_MediatR.Model.Tags.DTOs;
using MediatR;

namespace CQRS_MediatR.Model.Tags.Queries
{
    public class FilterByName : IRequest<ApplicationServiceResponse<List<TagQr>>>
    {
        public string? TagName { get; set; }
    }
}
