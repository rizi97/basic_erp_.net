using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ERP.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public Patient? Patient { get; set; }

        [Required]
        public Doctor? Doctor { get; set; }
    }
}
