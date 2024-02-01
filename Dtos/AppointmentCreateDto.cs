using HMS_ERP.Models;
using System.ComponentModel.DataAnnotations;

namespace HMS_ERP.Dtos
{
    public class AppointmentCreateDto
    {
        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
