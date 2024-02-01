using HMS_ERP.Models;
using System.Text.Json.Serialization;

namespace HMS_ERP.Dtos
{
    public class AppointmentReadDto
    {
        public int AppointmentId { get; set; }

        [JsonIgnore]
        public DateTime dateTime { get; set; }

        public string DateTime => dateTime.ToString("yyyy-MM-dd HH:mm");

        public PatientReadDto Patient { get; set; }

        public DoctorReadDto Doctor { get; set; }

    }
}
