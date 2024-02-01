using HMS_ERP.Models;
using System.Text.Json.Serialization;

namespace HMS_ERP.Dtos
{
    public class AppointmentDoctorReadDto
    {
        public int AppointmentId { get; set; }

        [JsonIgnore]
        public DateTime dateTime { get; set; }

        public string DateTime => dateTime.ToString("yyyy-MM-dd HH:mm");

        public object patient => new {
            Name = Patient?.PatientName,
            Diease = Patient?.PatientDescription
        };

        [JsonIgnore]
        public Patient Patient { get; set; }

        [JsonIgnore]
        public Doctor Doctor { get; set; }
    }
}
