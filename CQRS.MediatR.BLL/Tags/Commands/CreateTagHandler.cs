using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.MediatR.DAL.ApplicationDB;
using CQRS.MediatR.Model.Tags.Commands;
using CQRS.MediatR.Model.Tags.Entities;
using MediatR;

namespace CQRS.MediatR.BLL.Tags.Commands
{
    public class CreateTagHandler:IRequestHandler<CreateTag,Tag>
    {
        private readonly ApplicationDbContext _context;

        public CreateTagHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> Handle(CreateTag request, CancellationToken cancellationToken)
        {
            Tag tag = new()
            {
                TagName = request.TagName
            };

            await _context.Tags.AddAsync(tag);
            await _context.SaveChangesAsync();
            
            return tag;
        }
    }
}
