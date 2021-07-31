using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PrayWay.Application.Common.Dto;
using PrayWay.Application.Place.Queries.GetPlace;
using PrayWay.Infrastructure.Persistence.DbContexts;

namespace PrayWay.Application.Place.Queries.GetPlaceList
{
    public class GetPlaceListHandler : IRequestHandler<GetPlaceListQuery, QueryResultDto<PlaceListDto>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPlaceListHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public async Task<QueryResultDto<PlaceListDto>> Handle(GetPlaceListQuery request, CancellationToken cancellationToken)
        {
            var placesQuery = _dbContext.Places.AsQueryable();

            if (request.Skip > 0)
            {
                placesQuery = placesQuery.Skip(request.Skip.Value);
            }

            var places = await placesQuery.Take(request.Take ?? 10).ToListAsync(cancellationToken);

            return new QueryResultDto<PlaceListDto>
            {
                TotalCount = places.Count,
                Items = _mapper.Map<IList<PlaceListDto>>(places)
            };
        }
    }
}