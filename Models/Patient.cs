using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HMS_ERP.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string? PatientName { get; set; }

        [Required]
        [MinLength(4)]
        public string? PatientPassword { get; set;}

        [Required]
        [EmailAddress]
        public string? PatientEmail { get; set; }

        public string? PatientDescription { get; set; }

        [Required]
        public string? PatientGender { get; set; }
    }
}
