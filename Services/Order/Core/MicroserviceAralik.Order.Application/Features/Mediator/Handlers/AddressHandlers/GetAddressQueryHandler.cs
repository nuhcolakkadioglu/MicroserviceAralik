using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroserviceAralik.Order.Application.Features.Mediator.Queries.AddressQueries;
using MicroserviceAralik.Order.Application.Features.Mediator.Results.AddresResults;
using MicroserviceAralik.Order.Application.Interfaces;
using MicroserviceAralik.Order.Domain.Entities;

namespace MicroserviceAralik.Order.Application.Features.Mediator.Handlers.AddressHandlers;
public class GetAddressQueryHandler : IRequestHandler<GetAddressQuery, List<GetAddressQueryResult>>
{
    private readonly IReadRepository<Address> _readRepository;
    private readonly IMapper _mapper;

    public GetAddressQueryHandler(IMapper mapper, IReadRepository<Address> readRepository)
    {
        _mapper = mapper;
        _readRepository = readRepository;
    }

    public async Task<List<GetAddressQueryResult>> Handle(GetAddressQuery request, CancellationToken cancellationToken)
    {
        var query =await _readRepository.GetAllAsync();
        var mapData = _mapper.Map<List<GetAddressQueryResult>>(query);

        return mapData;
         
    }
}
