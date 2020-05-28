using Microsoft.AspNetCore.Mvc;



namespace MvcMovie.Controllers {
    public class HelloWorldController : Controller {
        public string Index() {
            return "This is my default action....";
        }

        public string Welcome() {
            return "This is my Welcome action method...";
        }
    }
}