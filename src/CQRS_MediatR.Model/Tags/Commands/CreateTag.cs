using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS_MediatR.Model.Framework;
using CQRS_MediatR.Model.Tags.Entities;
using MediatR;

namespace CQRS_MediatR.Model.Tags.Commands
{
    public class CreateTag : IRequest<ApplicationServiceResponse<Tag>>
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string TagName { get; set; }
    }
}
