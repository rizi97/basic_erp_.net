using System.ComponentModel.DataAnnotations;

namespace HMS_ERP.Dtos
{
    public class PatientLoginDto
    {
        [Required]
        public string? PatientName { get; set; }

        [Required]
        public string? PatientPassword { get; set; }
    }
}
