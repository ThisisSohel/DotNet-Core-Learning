using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {
            List<Person> personList = new List<Person>
            {
                new Person()
                {
                    PersonName = "Name1", DateOfBirth = Convert.ToDateTime("2020-02-02"), PersonGender = Gender.Male,
                },
                new Person()
                {
                    PersonName = "Name2", DateOfBirth = Convert.ToDateTime("2022-02-02"), PersonGender = Gender.Male,
                },
                new Person()
                {
                    PersonName = "Name3", DateOfBirth = Convert.ToDateTime("2021-02-02"), PersonGender = Gender.Male,
                },
                        new Person()
                {
                    PersonName = "Name4", DateOfBirth = Convert.ToDateTime("2010-02-02"), PersonGender = Gender.Male,
                },
                new Person()
                {
                    PersonName = "Name5", DateOfBirth = Convert.ToDateTime("2019-02-02"), PersonGender = Gender.Male,
                },
                new Person()
                {
                    PersonName = "Name6", DateOfBirth = Convert.ToDateTime("2021-02-02"), PersonGender = Gender.Male,
                },
            };
            ViewData["person"] = personList;
            ViewData["appTitle"] = "ASP .NET Core App";
            ViewData["bodyMessage"] = "Welcome to the App!";
            return View(personList);
        }

        [Route("personDetails/{name}")]
        public IActionResult Details(string name)
        {
            if (name == null)
                return Content("Name can not be empty!");

            List<Person> personList = new List<Person>
            {
                new Person()
                {
                    PersonName = "Name1", DateOfBirth = Convert.ToDateTime("2020-02-02"), PersonGender = Gender.Male,
                },
                new Person()
                {
                    PersonName = "Name2", DateOfBirth = Convert.ToDateTime("2022-02-02"), PersonGender = Gender.Male,
                },
                new Person()
                {
                    PersonName = "Name3", DateOfBirth = Convert.ToDateTime("2021-02-02"), PersonGender = Gender.Male,
                },
                        new Person()
                {
                    PersonName = "Name4", DateOfBirth = Convert.ToDateTime("2010-02-02"), PersonGender = Gender.Male,
                },
                new Person()
                {
                    PersonName = "Name5", DateOfBirth = Convert.ToDateTime("2019-02-02"), PersonGender = Gender.Male,
                },
                new Person()
                {
                    PersonName = "Name6", DateOfBirth = Convert.ToDateTime("2021-02-02"), PersonGender = Gender.Male,
                },
            };

            Person? personMatch = personList.Where(per => per.PersonName == name).FirstOrDefault();
            return View(personMatch);
        }

        [Route("person_product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person() { PersonName = "Sara", PersonGender = Gender.Female, DateOfBirth = Convert.ToDateTime("2004-07-01") };

            Product product = new Product() { ProductId = 1, ProductName = "Air Conditioner" };

            PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel() { PersonData = person, ProductData = product };
            return View(personAndProductWrapperModel);
        }
    }
}
