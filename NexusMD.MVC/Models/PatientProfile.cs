using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusMD.Data
{
    public class PatientProfile
    {
        [Key]
        public int PatientProfileId { get; set; }

        public List<Patient> Patients { get; set; }

        public List<Doctor> Doctors { get; set; }

        public List<Appointment> Appointments { get; set; }

    }
}
