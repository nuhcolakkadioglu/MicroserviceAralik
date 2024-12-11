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
public class GetAddressByIdQueryHandler(IReadRepository<Address> _readRepository, IMapper _mapper) : IRequestHandler<GetAddressByIdQuery, GetAdressByIdQueryResult>
{
    public async Task<GetAdressByIdQueryResult> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _readRepository.GetByIdAsync(request.Id);
        var mapData = _mapper.Map<GetAdressByIdQueryResult>(data);
        return mapData;
    }
}
