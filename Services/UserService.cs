using CytoscapeDijkstra2.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CytoscapeDijkstra2.Services
{
    public interface IUserService
    {
        User Authenticate(string login, string password);
        List<User> GetAll();
        User GetById(int id);
        User Create(string login, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }

    public class UserService : IUserService
    {
        private dijkstraContext context;

        public UserService(dijkstraContext context)
        {
            this.context = context;
        }

        public User Authenticate(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = context.Users.FirstOrDefault(x => x.Login == login);

            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.Password, user.PasswordSalt))
                return null;

            throw new NotImplementedException();
        }

        public User Create(string login, string password)
        {
            /*
            // TODO: walidacja:
            - null or puste znaki
            - dany login zajęty
            */
            var user = new User();

            user.Login = login;
            user.DateRegistration = DateTime.Now;
            user.IsDeleted = 0;

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.Password = passwordHash;
            user.PasswordSalt = passwordSalt;

            context.Users.Add(user);
            context.SaveChanges();

            return user;
        }

        public List<User> GetAll()
        {
            return context.Users.Where(p => p.IsDeleted == 0).ToList();
        }

        public User GetById(int id)
        {
            return context.Users.Where(p => p.Id == id && p.IsDeleted == 0).FirstOrDefault();
        }

        public void Update(User userData, string password = null)
        {
            var user = context.Users.Where(p => p.Id == userData.Id).FirstOrDefault();

            if (user == null)
                throw new ArgumentException("User does not exist.", "password");

            if (!string.IsNullOrEmpty(userData.Login))
                user.Login = userData.Login;

            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.Password = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            context.Users.Update(user);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = context.Users.Where(p => p.Id == id).FirstOrDefault();

            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) 
                throw new ArgumentNullException("password");

            if (string.IsNullOrWhiteSpace(password)) 
                throw new ArgumentException("Can't be empty.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
