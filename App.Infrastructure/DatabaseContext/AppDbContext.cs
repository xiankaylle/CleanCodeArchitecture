using App.Models;
using App.Shared.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DatabaseContext
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonContacts> PersonContacts { get; set; }
        public DbSet<MigrationItemEntity> MigrationItemEntity { get; set; }
        //public virtual DbSet<DatabaseTrackingUpdate> DatabaseTrackingUpdate { get; set; }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            return await Database.BeginTransactionAsync(cancellationToken);
        }

        protected virtual async Task UpdateEntries(IEnumerable<BaseEntity> entries, DateTime savedTime)
        {
            /*
             * This username will be coming from current user loggedin
             * Create a service that will hold the current user
             */
            const string username = "system"; 

            foreach (var entry in entries)
            {
                if (entry.Id == default || string.IsNullOrEmpty(entry.CreatedBy))
                {
                    entry.CreatedOn = savedTime;
                    entry.CreatedBy = username;
                }
                entry.UpdatedOn = savedTime;
                entry.UpdatedBy = username;
            }

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity &&
             (e.State == EntityState.Added || e.State == EntityState.Modified)).Select(x => x.Entity as BaseEntity);

            await UpdateEntries(entries, DateTime.UtcNow);

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
    
}
