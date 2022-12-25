using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.MediatR.Model.Framework;

namespace CQRS.MediatR.Model.Tags.Entities
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }
    }
}
