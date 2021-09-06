using System;
using FluentValidation;
using JAC.MusicVideoList.Domain.Core.Entities;

namespace JAC.MusicVideoList.Application.Main.Validators
{
    public class UserLoginValidator : AbstractValidator<UserLogin>
    {
        public UserLoginValidator()
        {
            RuleFor(user => user.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
            RuleFor(user => user.Password)
                .NotNull()
                .NotEmpty()
                .MinimumLength(6);
        }
    }
}
