using Microsoft.AspNetCore.Mvc;
using middleman.Models;

namespace middleman.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
   
    private readonly ILogger<RegisterController> _logger;
    private readonly IRegistrationService _registrationService;

    public RegisterController(ILogger<RegisterController> logger, IRegistrationService registrationService)
    {
        _logger = logger;
        _registrationService = registrationService;
    }

    [HttpPost("Consumer")]
    public IActionResult Register([FromBody] User model)
    {
        if(model == null)
        {
            return BadRequest("Invalid client request");
        }

        var isRegistered = _registrationService.RegisterUser(model);

        if (isRegistered)
        {
            return Ok("User registered successfully");
        }
        else
        {
            return BadRequest("Registration failed");
        }
    }
    [HttpPost("Seller")]
    public IActionResult RegisterSeller([FromBody] Seller model)
    {
        if (model == null)
        {
            return BadRequest("Invalid client request");
        }

        var isRegistered = _registrationService.RegisterSeller(model);

        if (isRegistered)
        {
            return Ok("User registered successfully");
        }
        else
        {
            return BadRequest("Registration failed");
        }
    }

}

