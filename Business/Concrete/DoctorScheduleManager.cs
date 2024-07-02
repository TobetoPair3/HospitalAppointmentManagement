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
    public class DoctorScheduleManager : IDoctorScheduleService
    {
        IDoctorScheduleDal _doctorScheduleDal;
        public DoctorScheduleManager(IDoctorScheduleDal doctorScheduleDal)
        {
            _doctorScheduleDal = doctorScheduleDal;
        }

        public IResult CreateDoctorSchedule(DoctorSchedule doctorSchedule)
        {
            _doctorScheduleDal.Add(doctorSchedule);
            return new SuccessResult(Messages.ScheduleAdded);
        }

        public IResult DeleteDoctorSchedule(DoctorSchedule doctorSchedule)
        {
            if (doctorSchedule != null)
            {
                _doctorScheduleDal.Delete(doctorSchedule);
                return new SuccessResult(Messages.ScheduleDeleted);
            }
            return new ErrorResult(Messages.ScheduleIsEmpty);
        }

        public IDataResult<List<DoctorSchedule>> GetDoctorSchedules(int doctorId)
        {
            return new SuccessDataResult<List<DoctorSchedule>>(_doctorScheduleDal.GetAll().Where(ds=>ds.DoctorId==doctorId).ToList());
        }

        public IResult UpdateDoctorSchedule(DoctorSchedule doctorSchedule)
        {
            _doctorScheduleDal.Update(doctorSchedule);
            return new SuccessResult(Messages.ScheduleUpdated);
        }
    }
}
