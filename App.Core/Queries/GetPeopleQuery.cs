using App.Core.Transports;
using App.Shared.Contracts;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Queries
{
    public class GetPeopleQuery : IRequest<List<GetPersonTransport>>
    {
    }

    public class GetPeopleQueryHandler : IRequestHandler<GetPeopleQuery, List<GetPersonTransport>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetPeopleQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GetPersonTransport>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Person.ToListAsync();

            var result = _mapper.Map<List<GetPersonTransport>>(data);

            return result;

        }
    }
}
