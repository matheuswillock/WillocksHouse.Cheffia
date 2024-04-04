using FluentValidation;
using WillocksHouse.Cheffia.Application.OwnerUseCases.OwnerDtos;

namespace WillocksHouse.Cheffia.WebApi.Controllers.Validations;

public class OwnerValidator : AbstractValidator<OwnerInputDto>
{
    public OwnerValidator()
    {
        RuleFor(owner => owner.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(owner => owner.Email).NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("A valid email is required.");
        RuleFor(owner => owner.Password).NotEmpty().WithMessage("Password is required.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$")
            .WithMessage("Password must be strong, at least six characters, one special character, contain uppercase and lowercase letters and be alphanumeric.");
        RuleFor(owner => owner.Document).NotEmpty().WithMessage("Document is required.");
    }
}