using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AppointmentManager : IAppointmentService
    {
        IAppointmentDal _appDal;
        IDoctorScheduleService _doctorScheduleService;
        public AppointmentManager(IAppointmentDal appointmentDal, IDoctorScheduleService doctorScheduleService)
        {
            _appDal = appointmentDal;
            _doctorScheduleService = doctorScheduleService;
        }
        public IResult CreateAppointment(Appointment appointment)
        {
            var doctorSchedule = _doctorScheduleService.GetDoctorSchedules(appointment.DoctorId);
            bool isAvailable = doctorSchedule.Data.Any(ds => appointment.AppDate >= ds.AvailableFrom && appointment.AppDate <= ds.AvailableTo);
            if(isAvailable)
            {
                _appDal.Add(appointment);
                return new SuccessResult(Messages.AppointmentAdded);
            }
            return new ErrorResult("Doktorun uygunluğu yok.");

            
        }

        public IDataResult<List<Appointment>> GetAvailableAppointments(int doctorId)
        {
            var doctorSchedules = _doctorScheduleService.GetDoctorSchedules(doctorId);

            var avaiableAppointments = new List<Appointment>();
            foreach(var schedule in doctorSchedules.Data)
            {
                var appointmentsInSchedule=_appDal.GetAll().Where(a=>a.DoctorId==doctorId&&a.AppDate>=schedule.AvailableFrom && a.AppDate <= schedule.AvailableTo).ToList();
                avaiableAppointments.AddRange(appointmentsInSchedule);
            }

            
            return new SuccessDataResult<List<Appointment>>(avaiableAppointments);
        }
    }
}
