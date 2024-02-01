using System.ComponentModel.DataAnnotations;

namespace HMS_ERP.Dtos
{
    public class PatientUpdateDto
    {
        [Required]
        public string? PatientName { get; set; }

        public string? PatientDescription { get; set; }

        [Required]
        public string? PatientGender { get; set; }
    }
}
