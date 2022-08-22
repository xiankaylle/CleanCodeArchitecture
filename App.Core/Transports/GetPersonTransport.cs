using App.Models;
using App.Shared.Common;
using Mapster;

namespace App.Core.Transports
{
    public class GetPersonTransport : BaseEntityTransport, IRegister
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{LastName}, {FirstName}"; } }
        public List<GetPersonContactsTransport> PersonContactsTransport { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Person, GetPersonTransport>()
            .Map(dest => dest.PersonId, src => src.Id)
            .Map(dest => dest.PersonContactsTransport, src => src.PersonContacts);

            config.NewConfig<GetPersonTransport, Person>()
            .Map(dest => dest.Id, src => src.PersonId)
            .Map(dest => dest.PersonContacts, src => src.PersonContactsTransport);

        }
    }
}
