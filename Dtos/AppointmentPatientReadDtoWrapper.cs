using HMS_ERP.Models;
using System.Text.Json.Serialization;

namespace HMS_ERP.Dtos
{
    public class AppointmentPatientReadDtoWrapper
    {
        public int TotalAppointments { get; set; }

        public string PatientName {  get; set; }
        public string PatientDescription {  get; set; }
        public string PatientGender {  get; set; }

        public IEnumerable<AppointmentPatientReadDto> Appointments { get; set; }
    }
}
