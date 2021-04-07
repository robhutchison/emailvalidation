using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using CustomerRegistration.Models.RequestModels;
using CustomerRegistration.Models.ResponseModels;
using CustomerRegistration.Models.Validators;
using Microsoft.AspNetCore.Http;

namespace CustomerRegistration.API.Controllers
{
	/// <summary>
	/// Controller for handling requests to register a customer
	/// </summary>
	[ApiController]
	[Route("[controller]")]
	
	public class CustomerRegistrationController : Controller
	{
		
		/// <summary>
		/// Attempts to register a user from the details in <paramref name="request"/>
		/// </summary>
		/// <param name="request"></param>
		/// <returns>a <see cref="CustomerRegistrationResponse"/> with the Customer Id if they were successfully registered else a list of the validation errors which occurred.</returns>
		[HttpPost("Register")]
		[Consumes(MediaTypeNames.Application.Json)]
		[Produces(MediaTypeNames.Application.Json)]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerRegistrationResponse))]
		[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CustomerRegistrationResponse))]
		public IActionResult RegisterCustomer(CustomerRegistrationRequest request)
		{
			var validator = new CustomerRegistrationRequestValidator();
			var results = validator.Validate(request);
			
			if (results.IsValid)
			{
				// save the details to the db
				var response = new CustomerRegistrationResponse();
				// todo: set the Id in the response based on the db record id
				return Ok(response);
			}
			else
			{
				var response = new CustomerRegistrationResponse
				{
					Errors = results.Errors.Select(x => x.ErrorMessage).ToArray()
				};
				return BadRequest(response);
			}

			
		}
	}
}
