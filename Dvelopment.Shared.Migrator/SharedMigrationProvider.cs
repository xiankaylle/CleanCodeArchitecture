using App.Infrastructure.DatabaseContext;
using Dvelopment.Shared.Migrator.DatabaseSeeder;

namespace Dvelopment.Shared.Migrator
{
    public class SharedMigrationProvider : BaseMigrationProvider
    {
        private readonly BaseMigration[] _migrations;
        private readonly BaseMigration[] _postMigrations;
        public SharedMigrationProvider(AppDbContext dbContext) : base(dbContext)
        {
            _migrations = new BaseMigration[]
              {
                  new PersonSeeder(dbContext)
              };
            _postMigrations = new BaseMigration[]
            { 
            
            };
        }

        public override IEnumerable<BaseMigration> GetMigrations()
        {
            return _migrations;
        }

        public override IEnumerable<BaseMigration> GetPostMigrations()
        {
            return _postMigrations;
        }
    }
}