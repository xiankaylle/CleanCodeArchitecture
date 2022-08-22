using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Dvelopment.Shared.Migrator
{
    public static class AppMigrator
    {
        public static async Task Run(IConfigurationRoot configuration, string migrationAssembly) {

            var databaseConnection = configuration.GetConnectionString("DefaultConnection");

            var migrationNamespaces = configuration.GetSection("MigrationNamespaces").Get<string[]>();
            var contextOptions =  new DbContextOptionsBuilder<AppDbContextMigrator>()
                                   .UseSqlServer(databaseConnection, x => x.MigrationsAssembly(migrationAssembly))
                                   .Options;


            await using var context = new AppDbContextMigrator(contextOptions);

            /*
             NOTE: Remove or comment the code bollow Ensure Deleted Async
             */

            Console.WriteLine("Deleting Database... ");
            await context.Database.EnsureDeletedAsync();
           
            Console.WriteLine("Creating Database... ");
            await InitializeDatabase(context);

            var history = await context.MigrationItemEntity.ToListAsync();
            foreach (var hist in history)
            {

                Console.WriteLine(hist.MigrationKey);
            }

            var allPostMigrations = new List<BaseMigration>();
            var sharedMigrationProvider = new SharedMigrationProvider(context);
            var sharedMigrations = sharedMigrationProvider.GetMigrations();

            foreach (var sharedMiration in sharedMigrations)
            {
                await sharedMiration.ExecuteMigations();
            }
            var sharedPostMigrations = sharedMigrationProvider.GetPostMigrations();

            if (sharedPostMigrations?.Any() ?? false)
            {
                allPostMigrations.AddRange(sharedPostMigrations);
            }

          
            foreach (var postMigration in allPostMigrations)
            {
                await postMigration.ExecuteMigations();
            }

            Console.WriteLine("Done...");
        }

        private static async Task InitializeDatabase(AppDbContextMigrator context)
        {
            var appliedMigrations = (await context.Database.GetAppliedMigrationsAsync()).ToList();
            var migrator = context.Database.GetInfrastructure().GetService<IMigrator>();
            foreach (var pendingMigrations in await context.Database.GetPendingMigrationsAsync())
            {
                if (!appliedMigrations.Contains(pendingMigrations))
                {
                    await migrator.MigrateAsync(pendingMigrations);
                }
            }
        }
    }
}
