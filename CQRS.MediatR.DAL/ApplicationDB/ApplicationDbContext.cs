using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.MediatR.DAL.Tags;
using CQRS.MediatR.Model.Tags.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS.MediatR.DAL.ApplicationDB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(TagConfiguration).Assembly);
            modelBuilder.ApplyConfiguration(new TagConfiguration());
        }
    }
}
