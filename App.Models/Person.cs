namespace App.Models
{
    public class Person : BaseEntity
    {
        public Person()
        {
            PersonContacts = new HashSet<PersonContacts>();
        }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<PersonContacts> PersonContacts { get; set; }

    }
}