using System;

namespace ApiAuth.Models {
    public class UserModel {
        public UserModel(string email, string name, string role, string password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Name = name;
            Role = role;
            Password = password;
        }
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string Role { get; private set; }
        public string Password { get; private set; }
        
        public void ChangePassword(string password) {
            Password = password;
        }
    }
}