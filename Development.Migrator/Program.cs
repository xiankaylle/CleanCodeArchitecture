// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Dvelopment.Shared.Migrator;

Console.WriteLine("Initialize Migration!");

var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

var configuration = builder.Build();

await AppMigrator.Run(configuration, typeof(Program).Assembly.FullName);

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContextMigrator>
{
    public AppDbContextMigrator CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");

        var configuration = builder.Build();

        var connectionString = configuration
                    .GetConnectionString("DefaultConnection");

        var dbContextOptionsBuilder = new DbContextOptionsBuilder();

        dbContextOptionsBuilder.UseSqlServer(connectionString,
                    x => x.MigrationsAssembly(typeof(AppDbContextFactory).Assembly.FullName));
        //dbContextOptionsBuilder.UseNpgsql(connectionString,
        //            x => x.MigrationsAssembly(typeof(GCCDbContextFactory).Assembly.FullName));

        return new AppDbContextMigrator(dbContextOptionsBuilder.Options);
    }
}
