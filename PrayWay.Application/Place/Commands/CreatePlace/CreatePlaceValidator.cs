using FluentValidation;

namespace PrayWay.Application.Place.Commands.CreatePlace
{
    public class CreatePlaceValidator : AbstractValidator<CreatePlaceCommand>
    {
        public CreatePlaceValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty();

            RuleFor(x => x.Address)
                .NotEmpty();

            RuleFor(x => x.Latitude)
                .NotEmpty();

            RuleFor(x => x.Longitude)
                .NotEmpty();
        }
    }
}