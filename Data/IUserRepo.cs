using HMS_ERP.Models;

namespace HMS_ERP.Data
{
    public interface IUserRepo<T>
    {
        public bool SaveChanges();

        IEnumerable<T> GetAllUsers();

        T GetUserById(int id);

        T GetUserByEmail(string email);

        T GetUserByUsernamePassword(string username, string password);

        void CreateUser(T user);

        void DeleterUser(T user);

        void UpdateUser(T user);
    }
}
