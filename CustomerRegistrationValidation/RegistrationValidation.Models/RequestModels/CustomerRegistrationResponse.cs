namespace RegistrationValidation.Models.RequestModels
{
	public class CustomerRegistrationResponse
	{
		public int CustomerId { get; set; }

		public string[] Errors { get; set; }
	}
}