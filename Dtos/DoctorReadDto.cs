using System.ComponentModel.DataAnnotations;

namespace HMS_ERP.Dtos
{
    public class DoctorReadDto
    {
        public int DoctorId { get; set; }

        public string? DoctorName { get; set; }

        public string? DoctorEmail { get; set; }

        public string? DoctorSpecialization { get; set; }

        public string? DoctorGender { get; set; }
    }
}
