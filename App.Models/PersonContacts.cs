using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    [Index(nameof(Type))]
    [Index(nameof(Value))]

    public class PersonContacts : BaseEntity
    {
        
        public string Type { get; set; }
        public string Value { get; set; }
        public long? PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public virtual Person Person { get; set; }

    }
}
