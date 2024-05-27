using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorServerCleanArchtecture.Application.Interfaces.Repositories;
using BlazorServerCleanArchtecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerCleanArchtecture.Application.Features.Stadiums.Queries.GetAllStadiums
{
    public record GetAllStadiumsQuery : IRequest<List<GetAllStadiumsDto>>;

    internal class GetAllStadiumsQueryHandler : IRequestHandler<GetAllStadiumsQuery, List<GetAllStadiumsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllStadiumsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<GetAllStadiumsDto>> Handle(GetAllStadiumsQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Stadium>().Entities
                .ProjectTo<GetAllStadiumsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
