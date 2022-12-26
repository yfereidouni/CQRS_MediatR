using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS_MediatR.Model.Framework;

namespace CQRS_MediatR.Model.Tags.Entities
{
    public class Tag : BaseEntity
    {
        public string TagName { get; set; }
    }
}
