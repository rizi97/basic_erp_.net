using HMS_ERP.Models;

namespace HMS_ERP.Data
{
    public interface IAppointmentRepo
    {
        public bool SaveChanges();

        public IEnumerable<Appointment> GetAllAppointements(int page, int limit);

        public IEnumerable<Appointment> GetAllDoctorRecords(int doctor_id);

        public IEnumerable<Appointment> GetAllPatientRecords(int patient_id);

        public Appointment GetAppointmentById(int id);

        public Doctor GetDoctorById(int id);

        public Patient GetPatientById(int id);

        public void CreateAppointment(Appointment appointment); 

        public void DeleteAppointment(Appointment appointment);

        public void DeletePatientAppointments(int patient_id);
    }
}
