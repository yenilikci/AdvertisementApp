using AdvertisementApp.UI.Models;
using FluentValidation;

namespace AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
        //[Obsolete]
        public UserCreateModelValidator()
        {
            //CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Password must be a minimum of 3 characters");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Confirm password does not match");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Firstname cannot be empty");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname cannot be empty");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Username must be a minimum of 3 characters");
            RuleFor(x => new
            {
                x.Username,
                x.Firstname
            }).Must(x => CanNotFirstname(x.Username, x.Firstname)).WithMessage("Username must not contain your name")
            .When(x => x.Username != null && x.Firstname != null);
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Gender cannot be empty"); ;
        }

        private bool CanNotFirstname(string Username, string Firstname)
        {
            return !Username.Contains(Firstname);
        }
    }
}
