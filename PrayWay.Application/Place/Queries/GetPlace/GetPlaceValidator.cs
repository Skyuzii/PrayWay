using FluentValidation;

namespace PrayWay.Application.Place.Queries.GetPlace
{
    public class GetPlaceValidator : AbstractValidator<GetPlaceQuery>
    {
        public GetPlaceValidator()
        {
            RuleFor(x => x.Id)
                .Must(x => x > 0)
                .WithMessage("Идентификатор не может быть пустым");
        }
    }
}