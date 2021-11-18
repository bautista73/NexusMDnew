using NexusMD.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusMD.Models.Appointment
{
    public class AppointmentEdit
    {
        public int AppointmentId { get; set; }
        public string Status { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Notes { get; set; }
        public bool Confirmation { get; set; }
        public ICollection<Data.Doctor> Doctors { get; set; }
        public ICollection<Data.Patient> Patients { get; set; }
    }
}
