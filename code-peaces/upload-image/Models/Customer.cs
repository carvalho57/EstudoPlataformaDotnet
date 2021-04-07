using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace upload_image.Models
{
    public class Customer
    {
        private Customer() { }
        public Customer(string firstName, string lastName, DateTime birthDate, string gender, string photo)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Gender = gender;
            PhotoFileName = photo;
        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName { get { return FirstName + LastName; } }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public string PhotoFileName { get; private set; }
    }
}