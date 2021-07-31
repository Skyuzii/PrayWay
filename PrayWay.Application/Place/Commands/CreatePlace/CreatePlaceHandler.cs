using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using PrayWay.Infrastructure.Persistence.DbContexts;

namespace PrayWay.Application.Place.Commands.CreatePlace
{
    public class CreatePlaceHandler : IRequestHandler<CreatePlaceCommand, int>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreatePlaceHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public async Task<int> Handle(CreatePlaceCommand request, CancellationToken cancellationToken)
        {
            var place = _mapper.Map<Domain.Entities.Place>(request);
            await _dbContext.Places.AddAsync(place, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return place.Id;
        }
    }
}