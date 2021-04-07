using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using upload_image.Data;
using upload_image.Models;

namespace upload_image.Controllers
{
    public class CustomerController : Controller
    {        
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CustomerController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {            
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var customerViewModels = _context.Customers
                        .Select(customer => CustomerViewModel.ToViewModel(customer))
                        .ToList();
            return View(customerViewModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
                return View();

            string uniqueFileName; 
            var sucessOperation = UploadedFile(customerViewModel,out uniqueFileName);

            if(!sucessOperation)
                return BadRequest();

            customerViewModel.FileName = uniqueFileName;
            var customer = customerViewModel.ToCustomer();
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool UploadedFile(CustomerViewModel viewModel, out string uniqueFileName)
        {
            uniqueFileName = string.Empty;

            if (viewModel.Photo == null)
                return false;            

            string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            uniqueFileName = Guid.NewGuid().ToString() + "." + Path.GetExtension(viewModel.Photo.FileName);  
            string filePath = Path.Combine(uploadFolder, uniqueFileName);  
            using (var fileStream = new FileStream(filePath, FileMode.Create))  
            {  
               viewModel.Photo.CopyTo(fileStream);  
            } 
            return true;
        }
    }
}
