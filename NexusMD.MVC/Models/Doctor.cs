using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusMD.Data
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public bool Availability { get; set; }

        public Specialty Specialization { get; set; }

        public enum Specialty
        {
            Anesthesiology = 1,
            Dermatology,
            Neurology,
            Surgery,
            Pathology,
            FamilyMedicine,
            EmergencyMedicine
        }
    }
}
