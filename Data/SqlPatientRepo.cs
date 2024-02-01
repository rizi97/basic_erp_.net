

using HMS_ERP.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMS_ERP.Data
{
    public class SqlPatientRepo : IUserRepo<Patient>
    {
        private readonly HmsErpContext _context;

        public SqlPatientRepo(HmsErpContext context) { 
            _context = context;
        }

        public IEnumerable<Patient> GetAllUsers()
        {
            return _context.Patients.ToList();
        }

        public Patient GetUserById(int id)
        {
            return _context.Patients.FirstOrDefault(p => p.PatientId == id);
        }

        public Patient GetUserByEmail(string email)
        {
            return _context.Patients.FirstOrDefault(p => p.PatientEmail == email);
        }

        public Patient GetUserByUsernamePassword(string username, string password)
        {
            return _context.Patients.FirstOrDefault(p => p.PatientName == username && p.PatientPassword == password);
        }

        public void CreateUser(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }

            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public void UpdateUser(Patient patient)
        {
            // Nothing
        }

        public void DeleterUser(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
