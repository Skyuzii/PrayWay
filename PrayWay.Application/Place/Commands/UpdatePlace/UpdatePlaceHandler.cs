using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PrayWay.Application.Common.Exceptions;
using PrayWay.Infrastructure.Persistence.DbContexts;

namespace PrayWay.Application.Place.Commands.UpdatePlace
{
    public class UpdatePlaceHandler : IRequestHandler<UpdatePlaceCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdatePlaceHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public async Task<Unit> Handle(UpdatePlaceCommand request, CancellationToken cancellationToken)
        {
            var place = await _dbContext.Places.FirstOrDefaultAsync(x => x.Id == request.Id,
                cancellationToken: cancellationToken);

            if (place == null) throw new NotFoundException();

            place = _mapper.Map<Domain.Entities.Place>(request);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}