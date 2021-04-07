namespace RegistrationValidation.Models.ResponseModels
{

	/// <summary>
	/// The response to the request to register a user
	/// </summary>
	public class CustomerRegistrationResponse
	{
		/// <summary>
		/// The customer id if they were successfully registered else null
		/// </summary>
		public int? CustomerId { get; set; }

		/// <summary>
		/// The list of validation errors if there are any
		/// </summary>
		public string[] Errors { get; set; }
	}
}