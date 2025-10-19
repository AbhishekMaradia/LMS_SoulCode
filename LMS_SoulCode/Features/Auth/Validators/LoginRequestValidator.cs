using FluentValidation;
using LMS_SoulCode.Features.Auth.Entities;
using LMS_SoulCode.Features.Auth.Models;

namespace LMS_SoulCode.Features.Auth.Validators
{

    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(user => user.UsernameOrEmail).NotEmpty().WithMessage("Username or email is required");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
