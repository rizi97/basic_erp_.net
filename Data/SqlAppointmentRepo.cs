using HMS_ERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

namespace HMS_ERP.Data
{
    public class SqlAppointmentRepo : IAppointmentRepo
    {
        private readonly HmsErpContext _context;

        public SqlAppointmentRepo(HmsErpContext context)
        {
            _context = context;   
        }

        public void CreateAppointment(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
        }

        public void DeleteAppointment(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }

        public void DeletePatientAppointments(int patient_id)
        {
            var appointments = _context.Appointments
                                .Where(a => a.PatientId == patient_id);

            _context.Appointments.RemoveRange(appointments);
            _context.SaveChanges();
        }

        public IEnumerable<Appointment> GetAllAppointements(int page, int limit)
        {
            IQueryable<Appointment> query = _context.Appointments
                                            .Include(a => a.Patient)
                                            .Include(a => a.Doctor);

            if (page > 0)
            {
                var skip = (page - 1) * limit;
                query = query.Skip(skip);
            }

            if (limit > 0 )
                query = query.Take(limit);

            return query.ToList();
        }

        public IEnumerable<Appointment> GetAllDoctorRecords(int doctor_id)
        {
            //var method = _context.Appointments
            //                .Where(a => a.DoctorId == doctor_id)
            //                .Include(a => a.Patient)
            //                .Include(a => a.Doctor)
            //                .ToList();

            //var query = (from a in _context.Appointments
            //             where a.DoctorId == doctor_id
            //             select new Appointment
            //             {
            //                 AppointmentId = a.AppointmentId,
            //                 DateTime = a.DateTime,
            //                 Patient = a.Patient,
            //                 Doctor = a.Doctor
            //             })
            //            .ToList();


            var apts = (from a in _context.Appointments
                        where a.DoctorId == doctor_id
                        select a
                        ).ToList();

            var join = (from ap in apts
                        join d in _context.Doctors
                        on ap.DoctorId equals d.DoctorId
                        join p in _context.Patients
                        on ap.PatientId equals p.PatientId
                        select ap).ToList();

            return join;
        }

        public IEnumerable<Appointment> GetAllPatientRecords(int patient_id)
        {
            //var method = _context.Appointments
            //                .Where(a => a.PatientId == patient_id)
            //                .Include(a => a.Patient)
            //                .Include(a => a.Doctor)
            //                .ToList();

            var query = (from a in _context.Appointments
                         where a.PatientId == patient_id
                         select new Appointment
                         {
                             AppointmentId = a.AppointmentId,
                             DateTime = a.DateTime,
                             Patient = a.Patient,
                             Doctor = a.Doctor
                         });

            return query;
        }

        public Appointment GetAppointmentById(int id)
        {
            return _context.Appointments.FirstOrDefault(p => p.AppointmentId == id);
        }

        public Doctor GetDoctorById(int id)
        {
            throw new NotImplementedException();
        }

        public Patient GetPatientById(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
