using FluentValidation;

namespace PrayWay.Application.Place.Commands.UpdatePlace
{
    public class UpdatePlaceValidator : AbstractValidator<UpdatePlaceCommand>
    {
        public UpdatePlaceValidator()
        {
            RuleFor(x => x.Id)
                .Must(x => x > 0)
                .WithMessage("'Id' должно быть заполнено.");
            
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