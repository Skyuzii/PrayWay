using MediatR;

namespace PrayWay.Application.Place.Queries.GetPlace
{
    public class GetPlaceQuery : IRequest<PlaceDto>
    {
        /// <summary>
        /// Индентификатор места
        /// </summary>
        public int Id { get; set; }
    }
}