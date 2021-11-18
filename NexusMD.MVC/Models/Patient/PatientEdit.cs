using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NexusMD.Data.Patient;

namespace NexusMD.Models.Patient
{
    public class PatientEdit
    {
        public int PatientId { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Genders BiologicalGender { get; set; }
        [Display(Name = "Birthdate"), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public Feet Height { get; set; }
        public Inches Height2 { get; set; }
        public double Weight { get; set; }
        public BloodTypes BloodType { get; set; }
    }
}
