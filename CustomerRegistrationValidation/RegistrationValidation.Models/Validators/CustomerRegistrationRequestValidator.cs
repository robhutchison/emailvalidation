using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using RegistrationValidation.Models.RequestModels;

namespace RegistrationValidation.Models.Validators
{
	public class CustomerRegistrationRequestValidator : AbstractValidator<CustomerRegistrationRequest>
	{
		public CustomerRegistrationRequestValidator()
		{
			RuleFor(c => c.FirstName).NotNull().Length(3,50);
			RuleFor(c => c.Surname).NotNull().Length(3, 50);
			RuleFor(c => c.ReferenceNumber).NotNull().Matches(@"^(?:[a-z,A-Z]){2}[/d]{6}$").WithMessage("Reference number must be in the format XX-123456");
			// todo: this error message needs to be clearer to the user
			RuleFor(c => c.Email).NotNull().Matches(@"^(?:[a-z,A-Z,0-9]){4,}\@(?:[a-z,A-Z,0-9]){2,}(?:.com|.co.uk)$").WithMessage("Email must be in the correct format");
			RuleFor(c => c.DateOfBirth).Must(dob => dob.AddYears(18) <= DateTime.Today).WithMessage("Customer must be at least 18 years old");
		}
		
	}
}
