using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


namespace MvcMovie.Controllers {
    public class HelloWorldController : Controller {

        //Get
        public IActionResult Index() {
            return View();
        }
        //Get
        public string Welcome(string name, int numTimes = 1) {
            ViewData["Message"] = $"Hello {name}";
            ViewData["NumTimes"] = {ID};


        }

            
    }
}