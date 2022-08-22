using App.Core.Transports;
using App.Shared.Contracts;
using App.Shared.ResponseWrapper;
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
    public class GetPersonByIdQuery : IServiceRequest<GetPersonTransport>
    {
        public int PersonId { get; set; }
    }

    public class GetPersonByIdQueryValidation : IValidationHandler<GetPersonByIdQuery>
    {
        private readonly IAppDbContext _context;
        public GetPersonByIdQueryValidation(IAppDbContext context)
        {
            _context = context;
        }
        public  async Task<ValidationResult> Validate(GetPersonByIdQuery request)
        {
            
            if (!(await _context.Person.AnyAsync(x => x.Id == request.PersonId)))
            {
                return new ValidationResult(ResponseStatusCode.EntityNotFound, $"Person does not exist!");
            }

            return Task.FromResult<ValidationResult>(null).Result;
        }

    }
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, ServiceResponse<GetPersonTransport>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;
        public GetPersonByIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetPersonTransport>> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Person.Where(p=>p.Id == request.PersonId).FirstOrDefaultAsync();

            var result = _mapper.Map<GetPersonTransport>(data);

            return new ServiceResponse<GetPersonTransport>()
            {
                Data = result
            };
        }
    }
}
