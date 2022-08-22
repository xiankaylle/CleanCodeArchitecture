using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    [Index(nameof(MigrationKey), IsUnique = true)]
    public class MigrationItemEntity : BaseEntity
    {
        public string MigrationKey { get; set; }
    }
}
