using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        IAppointmentService _appointmentService;
        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("CreateAppointment")]
        public IActionResult CreateAppointment(Appointment appointment)
        {
            var result=_appointmentService.CreateAppointment(appointment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetAvailableAppointments")]
        public IActionResult GetAvailableAppointments(int doctorId)
        {
            var result = _appointmentService.GetAvailableAppointments(doctorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();

        }
    }
}
