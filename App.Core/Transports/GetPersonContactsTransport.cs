using App.Models;
using App.Shared.Common;
using Mapster;


namespace App.Core.Transports
{
    public class GetPersonContactsTransport : BaseEntityTransport, IRegister
    {
        public string ContactType { get; set; }
        public string Value { get; set; }
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<PersonContacts, GetPersonContactsTransport>()
            .Map(dest => dest.ContactType, src => src.Type);

            config.NewConfig<GetPersonContactsTransport, PersonContacts>()
                .Map(dest => dest.Type, src => src.ContactType);
        }
    }
}
