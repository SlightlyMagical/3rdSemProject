using Application.DTOs;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult<User> RegisterUser(PostUserDTO dto)
        {
            try
            {
                var result = _authService.RegisterUser(dto);
                return Created("", result);
            }
            catch (ValidationException v)
            {
                return BadRequest(v.Message);
            }
            catch (System.Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginDTO dto)
        {
            try
            {
                return Ok(_authService.Login(dto));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
