using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace upload_image.Models
{
    public class CustomerViewModel
    {
        public CustomerViewModel() { }
        public CustomerViewModel(Guid id, string firstName, string lastName, string fullName, DateTime birthDate, string gender, string fileName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            FullName = fullName;
            BirthDate = birthDate;
            Gender = gender;
            FileName = fileName;
        }

        public Guid Id { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Informe o sobrenome")]
        [Display(Name = "SobreNome")]
        public string LastName { get; set; }

        public string FullName { get; set; }
        [Required(ErrorMessage = "Informe a data de nascimento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Selecione uma foto")]
        public IFormFile Photo { get; set; }

        public string FileName { get; set; }

        public Customer ToCustomer()
        {
            return new Customer(FirstName, LastName, BirthDate, Gender, FileName);
        }

        public static CustomerViewModel ToViewModel(Customer customer)
        {
            return new CustomerViewModel(customer.Id, customer.FirstName, customer.LastName, customer.FullName, customer.BirthDate, customer.Gender, customer.PhotoFileName);
        }
    }
}