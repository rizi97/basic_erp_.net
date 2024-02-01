using HMS_ERP.Models;
using System.Text.Json.Serialization;

namespace HMS_ERP.Dtos
{
    public class AppointmentDoctorReadDtoWrapper
    {
        public int TotalAppointments { get; set; }

        public string DoctorName {  get; set; }

        public string DoctorGender {  get; set; }

        public IEnumerable<AppointmentDoctorReadDto> Appointments { get; set; }
    }
}
