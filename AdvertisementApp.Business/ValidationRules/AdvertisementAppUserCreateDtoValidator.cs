using AdvertisementApp.Common.Enums;
using AdvertisementApp.Dtos;
using AdvertisementApp.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Business.ValidationRules
{
    public class AdvertisementAppUserCreateDtoValidator : AbstractValidator<AdvertisementAppUserCreateDto>
    {
        public AdvertisementAppUserCreateDtoValidator()
        {
            this.RuleFor(x => x.AdvertisementAppUserStatusId).NotEmpty();
            this.RuleFor(x => x.AdvertisementId).NotEmpty();
            this.RuleFor(x => x.AppUserId).NotEmpty();
            this.RuleFor(x => x.CVPath).NotEmpty().WithMessage("Please select a cv file");
            this.RuleFor(x => x.EndDate).NotEmpty().When(x => x.MilitaryStatusId == (int)MilitaryStatusType.Tecilli).WithMessage("Postponement date cannot be blank");
        }
    }
}
