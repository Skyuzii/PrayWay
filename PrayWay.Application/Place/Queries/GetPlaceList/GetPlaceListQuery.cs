using MediatR;
using PrayWay.Application.Common.Dto;

namespace PrayWay.Application.Place.Queries.GetPlaceList
{
    public class GetPlaceListQuery : IRequest<QueryResultDto<PlaceListDto>>
    {
        /// <summary>
        /// Широта
        /// </summary>
        public double? Latitude { get; set; }
        
        /// <summary>
        /// Долгота
        /// </summary>
        public double? Longitude { get; set; }
        
        /// <summary>
        /// Вернуть заданное количество записей
        /// </summary>
        public int? Take { get; set; }
        
        /// <summary>
        /// Пропускать заданное количество записей
        /// </summary>
        public int? Skip { get; set; }

        /// <summary>
        /// Радиус
        /// </summary>
        public int? Radius { get; set; }
    }
}