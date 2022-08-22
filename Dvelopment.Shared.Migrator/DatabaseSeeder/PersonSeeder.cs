using App.Infrastructure.DatabaseContext;
using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvelopment.Shared.Migrator.DatabaseSeeder
{
    public class PersonSeeder : BaseMigration
    {
        public PersonSeeder(AppDbContext dbContext) : base(dbContext, nameof(PersonSeeder))
        {
        }

        protected override async Task ProcessMigration()
        {
            await InitialMigration();
        }

        private async Task InitialMigration()
        {

            if (!(await TryAddMigration()))
            {
                return;
            }

            await DbContext.Person.AddRangeAsync(
                new Person
                {
                    FirstName = "CJ",
                    MiddleName = "I.",
                    LastName = "Felix",
                    PersonContacts = new List<PersonContacts> { 
                        new PersonContacts {
                             Type = "Mobile",
                             Value = "+639082870343"
                        },
                         new PersonContacts {
                             Type = "Email",
                             Value = "email@gmail.com"
                        },

                    }
                },
                new Person
                {
                    FirstName = "Khay",
                    MiddleName = "B.",
                    LastName = "Felix",
                    PersonContacts = new List<PersonContacts> {
                        new PersonContacts {
                             Type = "Mobile",
                             Value = "+639081234567"
                        },
                         new PersonContacts {
                             Type = "Email",
                             Value = "sample@gmail.com"
                        },

                    }
                });

        }
    }
}
