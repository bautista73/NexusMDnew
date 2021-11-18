using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusMD.Models.Doctor
{
    public class DoctorEdit
    {
        [Required]
        public int DoctorId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public Data.Doctor.Specialty Specialization { get; set; }

        public bool Availability { get; set; }
    }
}
