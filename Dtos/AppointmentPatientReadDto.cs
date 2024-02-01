using HMS_ERP.Models;
using System.Text.Json.Serialization;

namespace HMS_ERP.Dtos
{
    public class AppointmentPatientReadDto
    {
        public int AppointmentId { get; set; }

        [JsonIgnore]
        public DateTime dateTime { get; set; }

        public string DateTime => dateTime.ToString("yyyy-MM-dd HH:mm");

        public object doctor => new
        {
            Name = Doctor?.DoctorName,
            Major = Doctor?.DoctorSpecialization
        };

        [JsonIgnore]
        public Patient Patient { get; set; }

        [JsonIgnore]
        public Doctor Doctor { get; set; }
    }
}
