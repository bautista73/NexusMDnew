using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NexusMD.Models.Doctor
{
    public class DoctorListItem
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public Data.Doctor.Specialty Specialization { get; set; }
    }
}
