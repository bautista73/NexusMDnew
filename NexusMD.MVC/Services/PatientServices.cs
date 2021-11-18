using NexusMD.Data;
using NexusMD.Models.Patient;
using NexusMD.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NexusMD.Services
{
    public class PatientServices
    {
        public IEnumerable<SelectListItem> GetPatients()
        {
            using (var context = new ApplicationDbContext())
            {
                List<SelectListItem> x = context.Patients.AsNoTracking()
                    .OrderBy(n => n.FullName)
                        .Select(n =>
                        new SelectListItem
                        {
                            Value = n.PatientId.ToString(),
                            Text = n.FullName
                        }).ToList();
                var p = new SelectListItem()
                {
                    Value = null,
                    Text = "--- select patient ---"
                };
                x.Insert(0, p);
                return new SelectList(x, "Value", "Text");
            }
        }

        public bool CreatePatient(PatientCreate model)
        {
            var entity =
                new Patient()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    BiologicalGender = model.BiologicalGender,
                    BirthDate = model.BirthDate,
                    Address = model.Address,
                    Height = model.Height,
                    Height2 = model.Height2,
                    Weight = model.Weight,
                    BloodType = model.BloodType
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Patients.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PatientListItem> GetAllPatients()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.
                    Patients.
                    Select(
                                e => new PatientListItem()
                                {
                                    PatientId = e.PatientId,
                                    FullName = e.FullName,
                                    PhoneNumber = e.PhoneNumber,
                                    Address = e.Address
                                }
                          );
                return query.ToArray();
            }
        }

        public PatientDetail GetPatientById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.
                    Patients.
                    Single(e => e.PatientId == id);

                return
                    new PatientDetail
                    {
                        FullName = entity.FullName,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        PhoneNumber = entity.PhoneNumber,
                        BiologicalGender = entity.BiologicalGender,
                        BirthDate = entity.BirthDate,
                        Address = entity.Address,
                        Height = entity.Height,
                        Height2 = entity.Height2,
                        Weight = entity.Weight,
                        BloodType = entity.BloodType
                    };
            }
        }

        public bool UpdatePatient(PatientEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.
                    Patients.
                    Single(e => e.PatientId == model.PatientId);

                if (entity is null)
                    return false;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.PhoneNumber = model.PhoneNumber;
                entity.BiologicalGender = model.BiologicalGender;
                entity.BirthDate = model.BirthDate;
                entity.Address = model.Address;
                entity.Height = model.Height;
                entity.Height2 = model.Height2;
                entity.Weight = model.Weight;
                entity.BloodType = model.BloodType;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePatient(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.
                    Patients.
                    Single(e => e.PatientId == id);

                if (entity is null)
                    return false;

                ctx.Patients.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
