using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NexusMD.Data
{
    public class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        [Key]
        public int PatientId { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{FirstName} {LastName}";

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Sex At Birth")]
        public Genders BiologicalGender { get; set; }

        [Display(Name = "Birthdate"), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Age")]
        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (BirthDate > today.AddYears(-age)) age--;
                return age;
            }

            private set { }
        }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Feet")]
        public Feet Height { get; set; }

        [Display(Name = "Inches")]
        public Inches Height2 { get; set; }

        public string PatientHeight => $"{Height} {Height2}";

        public double Weight { get; set; }

        [Display(Name = "Blood Type")]
        public BloodTypes BloodType { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

        public IEnumerable<SelectListItem> Patients { get; set; }

        public enum Genders
        {
            Male = 1,
            Female,
            PreferNotToSay,
            //Custom (Type Here)       (Stretch Goal)
        }

        public enum Feet
        {
            [Display(Name = "0'")]
            ZeroFoot,
            [Display(Name = "1'")]
            OneFoot,
            [Display(Name = "2'")]
            TwoFeet,
            [Display(Name = "3'")]
            ThreeFeet,
            [Display(Name = "4'")]
            FourFeet,
            [Display(Name = "5'")]
            FiveFeet,
            [Display(Name = "6'")]
            SixFeet,
            [Display(Name = "7'")]
            SevenFeet,
            [Display(Name = "8'")]
            EightFeet,
            [Display(Name = "9'")]
            NineFeet,
            [Display(Name = "10'")]
            TenFeet
        }

        public enum Inches
        {
            [Display(Name = "0''")]
            ZeroInch,
            [Display(Name = "1''")]
            OneInch,
            [Display(Name = "2''")]
            TwoInches,
            [Display(Name = "3''")]
            ThreeInches,
            [Display(Name = "4''")]
            FourInches,
            [Display(Name = "5''")]
            FiveInches,
            [Display(Name = "6''")]
            SixInches,
            [Display(Name = "7''")]
            SevenInches,
            [Display(Name = "8''")]
            EightInches,
            [Display(Name = "9''")]
            NineInches,
            [Display(Name = "10''")]
            TenInches,
            [Display(Name = "11''")]
            ElevenInches
        }

        public enum BloodTypes
        {
            [Display(Name = "A+")]
            A_Positive = 1,
            [Display(Name = "A-")]
            A_Negative,
            [Display(Name = "B+")]
            B_Positive,
            [Display(Name = "B-")]
            B_Negative,
            [Display(Name = "AB+")]
            AB_Positive,
            [Display(Name = "AB-")]
            AB_Negative,
            [Display(Name = "O+")]
            O_Positive,
            [Display(Name = "O-")]
            O_Negative
        }
    }
}
