using Data;
using Domain.Client;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Validator
{
    public class UserValidator : AbstractValidator<User>
    {
        private readonly RestCountriesClient _restCountriesClient;
        public UserValidator(RestCountriesClient restCountriesClient)
        {
            _restCountriesClient = restCountriesClient;

            RuleFor(p => p.Name).MinimumLength(5);
            RuleFor(p => p.FamilyName).MinimumLength(5);
            RuleFor(p => p.Address).MinimumLength(5);
            RuleFor(p => p.EMailAdress).EmailAddress();
            RuleFor(p => p.Age).InclusiveBetween(20,60);
            RuleFor(p => p.Hired).NotNull();
            RuleFor(p => p.CountryOfOrigin).MustAsync(IsCityValid).WithMessage("City couldn't be found");
        }

        private async Task<bool> IsCityValid(string city, CancellationToken arg2)
        {
            return await _restCountriesClient.CheckCity(city);
        }

    }
}
