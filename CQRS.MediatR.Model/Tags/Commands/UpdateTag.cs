using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.MediatR.Model.Framework;
using CQRS.MediatR.Model.Tags.Entities;
using MediatR;

namespace CQRS.MediatR.Model.Tags.Commands
{
    public class UpdateTag : IRequest<ApplicationServiceResponse<Tag>>
    {
        [Required]
        [Range(1,int.MaxValue)]
        public int Id { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 2)]
        public string TagName { get; set; }
    }
}
