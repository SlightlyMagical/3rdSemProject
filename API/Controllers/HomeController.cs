using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<Coach>> GetAllCoaches()
        {
            try
            {
                return _userService.GetAllCoaches();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }
        [HttpGet]
        [Route("RebuildDB")]
        public void RebuildDB()
        {
            _userService.RebuildDB();
        }
    }
}