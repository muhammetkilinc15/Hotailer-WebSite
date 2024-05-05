using FluentValidation;
using HotelProject.WebUI.DTOs.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
	public class UpdateGuestValidator:AbstractValidator<UpdateGuestDto>
	{
        public UpdateGuestValidator()
        {
			RuleFor(x => x.Name)
			   .NotEmpty().WithMessage("Name space can not be null")
			   .Matches(@"^[^\d\W]+$").WithMessage("Name should not contain any digits or special characters");

			RuleFor(x => x.Suname)
				.NotEmpty().WithMessage("Surname space can not be null")
				.Matches(@"^[^\d\W]+$").WithMessage("Surname should not contain any digits or special characters");

			RuleFor(x => x.City)
				.NotEmpty().WithMessage("City space can not be null")
				.Matches(@"^[^\d\W]+$").WithMessage("City should not contain any digits or special characters");

		}
	}
}
