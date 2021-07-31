using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PrayWay.Application.Common.Exceptions;
using PrayWay.Infrastructure.Persistence.DbContexts;

namespace PrayWay.Application.Place.Queries.GetPlace
{
    public class GetPlaceHandler : IRequestHandler<GetPlaceQuery, PlaceDto>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPlaceHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public async Task<PlaceDto> Handle(GetPlaceQuery request, CancellationToken cancellationToken)
        {
            var place = await _dbContext.Places.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (place == null) throw new NotFoundException();

            return _mapper.Map<PlaceDto>(place);
        }
    }
}