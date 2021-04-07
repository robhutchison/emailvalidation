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
	/// <summary>
	/// Custom validator to ensure that the customer registration request is properly completed
	/// </summary>
	public class CustomerRegistrationRequestValidator : AbstractValidator<CustomerRegistrationRequest>
	{
		public CustomerRegistrationRequestValidator()
		{
			RuleFor(c => c.FirstName).NotNull().Length(3, 50);
			RuleFor(c => c.Surname).NotNull().Length(3, 50);
			RuleFor(c => c.ReferenceNumber).NotNull().Matches(@"^(?:[a-z,A-Z]){2}[/d]{6}$")
				.WithMessage("Reference number must be in the format XX-123456");

			// if the email is present then it must match the format
			RuleFor(c => c.Email)
				.Matches(@"^(?:[a-z,A-Z,0-9]){4,}\@(?:[a-z,A-Z,0-9]){2,}(?:.com|.co.uk)$")
				.WithMessage(
					"Email must be in the format 4 or more alphanumerics @ 2 or more alphanumerics and end with either .com or .co.uk")
				.When(request => !string.IsNullOrEmpty(request.Email));

			// if there is no email then the DOB must be supplied and must be at least 18 years ago
			When(request => string.IsNullOrEmpty(request.Email), () =>
			{
				RuleFor(c => c)
					.NotNull()
					.Must(request => request.DateOfBirth?.AddYears(18) <= request.RegistrationTime)
					.WithMessage("Customer must be at least 18 years old when they registered");
			});
		}

	}
}
