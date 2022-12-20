using Application;
using Application.DTOs;
using Application.Interfaces;
using Domain;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private IBookingService _bookingService;
        private IUserService _userService;

        public BookingController(IBookingService bookingService, IUserService userService)
        {
            _bookingService = bookingService;
            _userService = userService;
        }

        [Authorize("CoachPolicy")]
        [HttpPut]
        public ActionResult updateWorkingHours(WorkingHoursDTO dto)
        {
            try
            {
                if(_userService.UpdateWorkingHours(dto))
                    return Ok();
                return BadRequest("something went wrong");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
