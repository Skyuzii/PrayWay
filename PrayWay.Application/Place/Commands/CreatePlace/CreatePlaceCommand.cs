using AutoMapper;
using MediatR;
using PrayWay.Application.Common.Mappings;

namespace PrayWay.Application.Place.Commands.CreatePlace
{
    public class CreatePlaceCommand : IRequest<int>, IMapFrom<Domain.Entities.Place>
    {
        public string Title { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
        
        public string Description { get; set; }
        public string Address { get; set; }  
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePlaceCommand, Domain.Entities.Place>();
            profile.CreateMap<CreatePlaceCommand, Domain.Entities.Place>().ReverseMap();
        }
    }
}