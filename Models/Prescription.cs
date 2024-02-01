using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HMS_ERP.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }

        [Required]
        public string? Medicine { get; set; }

        public string? SpecialIntructions { get; set; }

        [Required]
        public Patient? Patient { get; set; }

        [Required]
        public Doctor? Doctor { get; set; }
    }
}
