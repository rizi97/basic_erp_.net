using System.ComponentModel.DataAnnotations;

namespace HMS_ERP.Models
{
    public class RoomAllocate
    {
        [Key]
        public int RoomId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public Patient? Patient { get; set; }
    }
}
