using NexusMD.Data;
using NexusMD.Models.Doctor;
using NexusMD.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusMD.Services
{
    public class DoctorService
    {
        public bool CreateDoctor(DoctorCreate model)
        {
            var entity =
                new Doctor()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Specialization = model.Specialization
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Doctors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DoctorListItem> GetAllDoctors()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.
                    Doctors.
                    Select(
                                e => new DoctorListItem()
                                {
                                    DoctorId = e.DoctorId,
                                    FullName = e.FullName,
                                    PhoneNumber = e.PhoneNumber,
                                    Specialization = e.Specialization
                                }
                          );
                return query.ToArray();
            }
        }

        public DoctorDetail GetDoctorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.
                    Doctors.
                    Single(e => e.DoctorId == id);

                return
                    new DoctorDetail
                    {
                        DoctorId = entity.DoctorId,
                        FullName = entity.FullName,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        PhoneNumber = entity.PhoneNumber,
                        Availability = entity.Availability,
                        Specialization = entity.Specialization
                    };
            }
        }

        public bool UpdateDoctor(DoctorEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.
                    Doctors.
                    Single(e => e.DoctorId == model.DoctorId);

                if (entity is null)
                    return false;

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Availability = model.Availability;
                entity.Specialization = model.Specialization;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteDoctor(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.
                    Doctors.
                    Single(e => e.DoctorId == id);

                if (entity is null)
                    return false;

                ctx.Doctors.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
