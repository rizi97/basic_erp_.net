using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HMS_ERP.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        public string? DoctorName { get; set; }

        [Required]
        [EmailAddress]
        public string? DoctorEmail { get; set; }

        [Required]
        public string? DoctorSpecialization { get; set; }

        [Required]
        public string? DoctorGender { get; set; }
    }
}
