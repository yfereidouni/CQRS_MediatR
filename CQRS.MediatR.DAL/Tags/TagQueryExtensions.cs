using CQRS.MediatR.Model.Tags.DTOs;
using CQRS.MediatR.Model.Tags.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CQRS.MediatR.DAL.Tags
{
    public static class TagQueryExtensions
    {
        public static IQueryable<Tag> WhereOver(this IQueryable<Tag> tags, string tagName)
        {
            if (!string.IsNullOrEmpty(tagName))
                tags = tags.Where(x => x.TagName.Contains(tagName));
            return tags;
        }

        public static List<TagQr> ToTagQr(this IQueryable<Tag> tags)
        {
            return tags.Select(c => new TagQr
            {
                Id = c.Id,
                TagName = c.TagName,
            }).ToList();
        }

        public static async Task<List<TagQr>> ToTagQrAsync(this IQueryable<Tag> tags)
        {
            return await tags.Select(c => new TagQr
            {
                Id = c.Id,
                TagName = c.TagName,
            }).ToListAsync();
        }
    }
}
