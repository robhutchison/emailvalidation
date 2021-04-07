using System;

namespace CustomerRegistration.Models.RequestModels
{
	/// <summary>
	/// Provides the details to be used to register customer details
	/// </summary>
	public class CustomerRegistrationRequest
	{
		/// <summary>
		/// The first name of the customer
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// The surname of the customer
		/// </summary>
		public string Surname { get; set; }

		/// <summary>
		/// The reference number of the customer in the format XX-123456
		/// </summary>
		public string ReferenceNumber { get; set; }

		/// <summary>
		/// The date of birth of the customer.
		/// </summary>
		/// <remarks>Optional if the customer email is supplied</remarks>
		public DateTime? DateOfBirth { get; set; }

		/// <summary>
		/// The customer email address
		/// </summary>
		/// <remarks>Optional if the date of birth is supplied and needs to be in the format 4 or more alphanumerics @ 2 or more alphanumerics and end with either .com or .co.uk</remarks>
		public string Email { get; set; }

		/// <summary>
		/// The date when the customer registered. Defaults to today if not supplied
		/// </summary>
		/// <remarks>Used to calculate the users age when they registered</remarks>
		public DateTime RegistrationTime { get; set; } = DateTime.Today;

	}
}
