using System.ComponentModel.DataAnnotations;

namespace HMS_ERP.Dtos
{
    public class PatientReadDto
    {
        public int PatientId { get; set; }

        public string? PatientName { get; set; }

        public string? PatientEmail { get; set; }

        public string? PatientDescription { get; set; }

        public string? PatientGender { get; set; }
    }
}
