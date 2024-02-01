using System.ComponentModel.DataAnnotations;

namespace HMS_ERP.Dtos
{
    public class DoctorCreateDto
    {
        [Required]
        public string? DoctorName { get; set; }

        [Required]
        public string? DoctorEmail { get; set; }

        [Required]
        public string? DoctorSpecialization { get; set; }

        [Required]
        public string? DoctorGender { get; set; }
    }
}
