using NexusMD.Data;
using NexusMD.Models.Doctor;
using NexusMD.Models.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusMD.Models.Appointment
{
    public class AppointmentListItem
    {
        public int AppointmentId { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public bool Confirmation { get; set; }
        public DateTime StartDateTime { get; set; }
        public ICollection<Data.Doctor> Doctors { get; set; }
        public ICollection<Data.Patient> Patients { get; set; }

        public int DoctorId { get; set; }
        public virtual Data.Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public virtual Data.Patient Patient { get; set; }
    }
}
