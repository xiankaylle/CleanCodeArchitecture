using App.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dvelopment.Shared.Migrator
{
    public abstract class BaseMigration
    {
        private readonly string _migrationIdentifierKey;
        protected BaseMigration(AppDbContext dbContext, string migrationIdentifierKey)
        {
            DbContext = dbContext;
            _migrationIdentifierKey = migrationIdentifierKey ?? throw new ArgumentNullException(migrationIdentifierKey);
        }

        protected AppDbContext DbContext { get; }

        /// <summary>
        /// Execute Migration 
        /// </summary>
        /// <returns></returns>
        public async Task ExecuteMigations()
        {
            using var transaction = await DbContext.BeginTransactionAsync();
            await ProcessMigration();
            await DbContext.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        protected abstract Task ProcessMigration();

        protected async Task<bool> TryAddMigration([CallerMemberName] string migrationKey = null)
        {
            var migrationItemKey = CreateMigrationItemKey(migrationKey);
            if (await DbContext.MigrationItemEntity.AnyAsync(x => x.MigrationKey == migrationItemKey))
            {
                return false;
            }

            await DbContext.MigrationItemEntity.AddAsync(new App.Models.MigrationItemEntity()
            {
                MigrationKey = migrationItemKey
            });

            return true;
        }

        protected string CreateMigrationItemKey([CallerMemberName] string migrationKey = null)
        {
            return $"{_migrationIdentifierKey}|{migrationKey}";
        }
    }
}
