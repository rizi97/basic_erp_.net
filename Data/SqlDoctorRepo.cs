using HMS_ERP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HMS_ERP.Data
{
    public class SqlDoctorRepo : IUserRepo<Doctor>
    {
        private readonly HmsErpContext _context;

        public SqlDoctorRepo(HmsErpContext context)
        {
            _context = context;
        }

        public IEnumerable<Doctor> GetAllUsers()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetUserById(int id)
        {
            return _context.Doctors.FirstOrDefault(p => p.DoctorId == id);
        }

        public Doctor GetUserByEmail(string email)
        {
            return _context.Doctors.FirstOrDefault(p => p.DoctorEmail == email);
        }

        public void CreateUser(Doctor doctor)
        {
            if (doctor == null)
                throw new ArgumentNullException(nameof(doctor));
            
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
        }

        public void UpdateUser(Doctor doctor)
        {
            // Nothing
        }

        public void DeleterUser(Doctor doctor)
        {
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        Doctor IUserRepo<Doctor>.GetUserByUsernamePassword(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
