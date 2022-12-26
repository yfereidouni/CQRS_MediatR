using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CQRS_MediatR.DAL.Framework
{
    public class AddAuditFieldInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            SetShadowProperties(eventData);

            return base.SavingChanges(eventData, result);
        }
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            SetShadowProperties(eventData);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private static void SetShadowProperties(DbContextEventData eventData)
        {
            var changeTracker = eventData.Context.ChangeTracker;
            var addedEntities = changeTracker.Entries().Where(c => c.State == EntityState.Added);
            var modifiedEntities = changeTracker.Entries().Where(c => c.State == EntityState.Modified);

            foreach (var item in addedEntities)
            {
                item.Property("CreateBy").CurrentValue = "1";
                item.Property("CreateDate").CurrentValue = DateTime.Now;
                item.Property("UpdateBy").CurrentValue = "1";
                item.Property("UpdateDate").CurrentValue = DateTime.Now;
            }

            foreach (var item in modifiedEntities)
            {
                item.Property("UpdateBy").CurrentValue = "2";
                item.Property("UpdateDate").CurrentValue = DateTime.Now;
            }
        }

    }
}
