using System;
using System.Collections.Generic;
using System.Linq;
using ApiAuth.Models;

namespace ApiAuth.Repositories
{
    public class UserRepository
    {
        private readonly List<UserModel> _users;

        public UserRepository() {
            _users = new List<UserModel>() {
                new UserModel("gabrielcarvalho572@outlook.com","gabriel", "user","gabriel"),
                new UserModel("admin@admin.com","Administrador", "admin","admin"),
                new UserModel("tails@outlook.com","Tail", "user","tail"),
            };
        }

        public bool EmailExist(string email) => _users.Any(user => user.Email == email);
        public void Update(UserModel usermodel)
        {
            Remove(usermodel.Id);
            _users.Add(usermodel);
        }

        public void Remove(Guid id) {
            var user = _users.Find(user => user.Id == id);    
            _users.Remove(user);
        }

        public void Add(UserModel user) {
            _users.Add(user);
        }

        public IReadOnlyCollection<UserModel> Get() => _users;
        public UserModel GetByEmail(string email) => _users.FirstOrDefault(user => user.Email == email);

    }
}