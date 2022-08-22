using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared.Contracts
{
    /// <summary>
    /// Resides the DB Set Entities
    /// </summary>
    public interface IAppDbContext : IDbContext
    {
        DbSet<Person> Person { get; set; }
        DbSet<PersonContacts> PersonContacts { get; set; }
        DbSet<MigrationItemEntity> MigrationItemEntity { get; set; }

    }
}
