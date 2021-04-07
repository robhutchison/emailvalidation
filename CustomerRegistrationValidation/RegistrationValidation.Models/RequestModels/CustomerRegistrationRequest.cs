using System;

namespace RegistrationValidation.Models.RequestModels
{
	public class CustomerRegistrationRequest
	{
		public string FirstName { get; set; }
		public string Surname { get; set; }

		public string ReferenceNumber { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public string Email { get; set; }

		public DateTime RegistrationTime { get; set; } = DateTime.Today;

	}
}
