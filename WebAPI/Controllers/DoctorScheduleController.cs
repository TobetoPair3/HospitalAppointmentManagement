using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        IDoctorScheduleService _doctorScheduleService;
        public DoctorScheduleController(IDoctorScheduleService doctorScheduleService)
        {
            _doctorScheduleService = doctorScheduleService;
        }

        [HttpGet("GetDoctorSchedules")]
        public IActionResult GetDoctorSchedules(int doctorId)
        {
            var result = _doctorScheduleService.GetDoctorSchedules(doctorId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPost]
        public IActionResult CreateDoctorSchedule(DoctorSchedule schedule)
        {
            var result = _doctorScheduleService.CreateDoctorSchedule(schedule);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }





        [HttpPut("UpdateDoctorSchedule")]
        public IActionResult UpdateDoctorSchedule(int id, DoctorSchedule schedule)
        {
            if (id != schedule.Id)
            {
                return BadRequest();
            }

            _doctorScheduleService.UpdateDoctorSchedule(schedule);
            return Ok();
        }

        [HttpDelete("DeleteDoctorSchedule")]
        public IActionResult DeleteDoctorSchedule(DoctorSchedule doctorSchedule)
        {
            var result = _doctorScheduleService.DeleteDoctorSchedule(doctorSchedule);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
        }





    }
}
