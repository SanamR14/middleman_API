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

    [HttpPost("consumer")]
    public IActionResult Register(User model)
    {
        if(model == null)
        {
            return BadRequest("Invalid client request");
        }

        var isRegistered = _registrationService.RegisterUser(model);

        if (isRegistered)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }
    [HttpPost("seller")]
    public IActionResult RegisterSeller(Seller model)
    {
        if (model == null)
        {
            return BadRequest("Invalid client request");
        }

        var isRegistered = _registrationService.RegisterSeller(model);

        if (isRegistered)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    [HttpGet("product")]
    public IActionResult GetAllProduct()
    {
        List<Product> product = _registrationService.GetAllProduct();

        if (product == null || product.Count == 0)
        {
            return NotFound("No users found.");
        }

        return Ok(product);
    }

    [HttpGet("users")]
    public IActionResult GetAllUsers()
    {
        List<User> user = _registrationService.GetAllUsers();

        if (user == null || user.Count == 0)
        {
            return NotFound("No users found.");
        }

        return Ok(user);
    }

}

