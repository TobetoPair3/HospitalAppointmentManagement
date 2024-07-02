using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDoctorScheduleService
    {
        IResult CreateDoctorSchedule(DoctorSchedule doctorSchedule);
        IResult UpdateDoctorSchedule(DoctorSchedule doctorSchedule);
        IResult DeleteDoctorSchedule(DoctorSchedule doctorSchedule);

        IDataResult<List<DoctorSchedule>> GetDoctorSchedules(int doctorId);
        //IDataResult<List<DoctorSchedule>> GetAllDoctorSchedules(DoctorSchedule doctorSchedule);


    }
}
