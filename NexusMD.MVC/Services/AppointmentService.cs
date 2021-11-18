using NexusMD.Data;
using NexusMD.Models.Appointment;
using NexusMD.MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusMD.Services
{
    public class AppointmentService
    {
        private readonly ApplicationDbContext _ctx = new ApplicationDbContext();

        public bool CreateAppointment(AppointmentCreate model)
        {
            var entity = new Appointment()
            {
                    Doctors = model.Doctors,
                    Patients = model.Patients,
                    StartDateTime = model.StartDateTime,
                    Status = model.Status,
                    Notes = model.Notes,
                    Confirmation = model.Confirmation
            };

                _ctx.Appointments.Add(entity);
                return _ctx.SaveChanges() == 1;
        }

        public IEnumerable<AppointmentListItem> GetAllAppointments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    _ctx.
                    Appointments.
                    Select(
                                e => new AppointmentListItem() 
                                {
                                    AppointmentId = e.AppointmentId,
                                    Doctor = e.Doctor,
                                    Patient = e.Patient,
                                    Status = e.Status,
                                    Notes = e.Notes,
                                    Confirmation = e.Confirmation,
                                    StartDateTime = e.StartDateTime
                                }
                          );
                return query.ToArray();
            }
        }

        public AppointmentDetail GetAppointmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    _ctx.
                    Appointments.
                    Find(id);
                if (entity is null)
                    return null;

                return
                    new AppointmentDetail
                    {
                        AppointmentId = entity.AppointmentId,
                        Doctors = entity.Doctors,
                        Patiens = entity.Patients,
                        StartDateTime = entity.StartDateTime,
                        Status = entity.Status,
                        Notes = entity.Notes,
                        Confirmation = entity.Confirmation
                    };
            }
        }

        public bool UpdateAppointment(AppointmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    _ctx.
                    Appointments.
                    Single(e => e.AppointmentId == model.AppointmentId);

                if (entity is null)
                    return false;
                entity.Doctors = model.Doctors;
                entity.Patients = model.Patients;
                entity.StartDateTime = model.StartDateTime;
                entity.Confirmation = model.Confirmation;
                entity.Notes = model.Notes;

                return _ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAppointment(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    _ctx.
                    Appointments.
                    Single(e => e.AppointmentId == id);

                if (entity is null)
                    return false;

                _ctx.Appointments.Remove(entity);
                return _ctx.SaveChanges() == 1;
            }
        }
    }
}
