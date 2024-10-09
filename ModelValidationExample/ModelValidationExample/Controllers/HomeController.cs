using Microsoft.AspNetCore.Mvc;
using ModelValidationExample.Models;

namespace ModelValidationExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("registration")]
        public IActionResult Index(Person person)
        {
            if(!ModelState.IsValid)
            {
                string errors = string.Join("\n",ModelState.Values.SelectMany(value =>
                value.Errors).Select(err => err.ErrorMessage).ToList());
                //List<string> errorList = new List<string>();
                //foreach(var error in ModelState.Values)
                //{
                //    foreach(var item in error.Errors)
                //    {
                //        errorList.Add(item.ErrorMessage);
                //    }
                //}
                //string errors = string.Join("\n", errorList);
                return BadRequest(errors);
            }
            return Content($"Person Details {person}");
            //return View();
        }
    }
}
