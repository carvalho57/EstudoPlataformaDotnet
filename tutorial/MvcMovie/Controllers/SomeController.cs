using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Models;
using MvcMovie.ViewModels;

namespace MvcMovie.Controllers
{
    public class SomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        public IActionResult Index()
        {
            ViewData["Greeting"] = "Hello";
            Title = "SomeAction - Index";
            ViewBag.Bag = "Beg";
            ViewData["Address"] = new Address()
            {
                Name = "Steve",
                Street = "123 Main St",
                City = "Hudson",
                State = "OH",
                PostalCode = "44236"
            };

            return View();
        }
        [NonAction]
        public IActionResult OtherAction(){
            return View();
        }
    }
}
