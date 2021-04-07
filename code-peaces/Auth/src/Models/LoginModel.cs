using System;

namespace ApiAuth.Models {
    public class LoginModel {
        public LoginModel(string email, string password)
        {
            Email = email;         
            Password = password;
        }        
        public string Email { get; private set; }
        public string Password { get; private set; }    
    }
}