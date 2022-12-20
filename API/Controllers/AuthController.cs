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
        public ActionResult RegisterUser(PostUserDTO dto)
        {
            try
            {
                return Ok(_authService.RegisterUser(dto));
            }
            catch (ValidationException v)
            {
                return BadRequest(v.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
