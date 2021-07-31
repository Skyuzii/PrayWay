using AutoMapper;
using MediatR;
using PrayWay.Application.Common.Mappings;

namespace PrayWay.Application.Place.Commands.UpdatePlace
{
    public class UpdatePlaceCommand : IRequest, IMapFrom<Domain.Entities.Place>
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
        
        public string Description { get; set; }
        
        public string Address { get; set; }  
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePlaceCommand, Domain.Entities.Place>();
            profile.CreateMap<UpdatePlaceCommand, Domain.Entities.Place>().ReverseMap();
        }
    }
}