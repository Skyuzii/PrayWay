using System;
using AutoMapper;
using PrayWay.Application.Common.Mappings;

namespace PrayWay.Application.Place.Queries.GetPlace
{
    public class PlaceDto : IMapFrom<Domain.Entities.Place>
    {
        public int Id { get; set; }
        
        public string Title { get; set; }
        
        public double Latitude { get; set; }
        
        public double Longitude { get; set; }
        
        public string Description { get; set; }
        
        public DateTime PublishDate { get; set; }
        
        public string Address { get; set; }  
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PlaceDto, Domain.Entities.Place>();
            profile.CreateMap<PlaceDto, Domain.Entities.Place>().ReverseMap();
        }
    }
}