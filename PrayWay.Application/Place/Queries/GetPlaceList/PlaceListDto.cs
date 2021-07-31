using AutoMapper;
using PrayWay.Application.Common.Mappings;

namespace PrayWay.Application.Place.Queries.GetPlaceList
{
    public class PlaceListDto : IMapFrom<Domain.Entities.Place>
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PlaceListDto, Domain.Entities.Place>();
            profile.CreateMap<PlaceListDto, Domain.Entities.Place>().ReverseMap();
        }
    }
}