using System;
using FluentValidation;
using JAC.MusicVideoList.Application.Main.DTOs;

namespace JAC.MusicVideoList.Application.Main.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(user => user.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
            RuleFor(user => user.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5);
            RuleFor(user => user.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6);
            RuleFor(user => user.Role)
                .NotNull()
                .NotEmpty();

        }
    }
}
