using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NexusMD.Models.Doctor
{
    public class DoctorDetail
    {
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public bool Availability { get; set; }
        public Data.Doctor.Specialty Specialization { get; set; }
    }
}
