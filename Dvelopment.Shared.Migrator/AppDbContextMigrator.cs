using App.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvelopment.Shared.Migrator
{
    public class AppDbContextMigrator : AppDbContext
    {
        public AppDbContextMigrator(DbContextOptions options) : base(options)
        {
        }
    }
}
