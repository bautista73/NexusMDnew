using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NexusMD.Data
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string Status { get; set; }

        [Display(Name = "Scheduled Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDateTime { get; set; }
        public string Notes { get; set; }
        public bool Confirmation { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Patient> Patients { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
