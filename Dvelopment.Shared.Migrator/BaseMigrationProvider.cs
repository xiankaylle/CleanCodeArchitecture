using App.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvelopment.Shared.Migrator
{
    public abstract class BaseMigrationProvider
    {
        private readonly AppDbContext _dbContext;

        protected BaseMigrationProvider(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get the Migration Implementation
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public abstract IEnumerable<BaseMigration> GetMigrations();
        /// <summary>
        /// Gets the Post Migrations
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<BaseMigration> GetPostMigrations()
        {
            return System.Array.Empty<BaseMigration>();
        }
    }
}
