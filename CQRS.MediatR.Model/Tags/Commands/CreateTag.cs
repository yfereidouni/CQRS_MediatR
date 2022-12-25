using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.MediatR.Model.Tags.Entities;
using MediatR;

namespace CQRS.MediatR.Model.Tags.Commands
{
    public class CreateTag : IRequest<Tag>
    {
        public string TagName { get; set; }
    }
}
