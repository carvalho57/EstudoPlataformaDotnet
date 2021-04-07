using System;

namespace ApiAuth.Models {
    public class AccountResult {
        public AccountResult(bool sucess, object data)
        {
            Sucess = sucess;
            Data = data;
        }

        public AccountResult(bool sucess, string message) {
            Sucess = sucess;
            Message = message;
        }

          public AccountResult(bool sucess, object data, string message) {
            Sucess = sucess;
            Data = data;
            Message = message;
        }


        public bool Sucess{ get; set; }
        public object Data{ get; set; }
        public string Message {get;set;}
    }
}