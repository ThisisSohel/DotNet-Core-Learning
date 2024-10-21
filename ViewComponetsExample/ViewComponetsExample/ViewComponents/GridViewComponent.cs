using Microsoft.AspNetCore.Mvc;
using ViewComponetsExample.Models;

namespace ViewComponetsExample.ViewComponents
{
    public class GridViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            PersonGridModel model = new PersonGridModel()
            {
                GridTitle = "Person List",
                Persons = new List<Person>
                {
                    new Person
                    {
                        PersonName = "Sakib",
                        JobTitle = "Jr. Software Engineer",
                    },
                    new Person
                    {
                        PersonName = "Rakib",
                        JobTitle = "Sr. Software Engineer",
                    },
                    new Person
                    {
                        PersonName = "Sadik",
                        JobTitle = "Software Engineer",
                    },
                }
            };
            ViewData["Grid"] = model;
            return View("Sample");
        }

    }
}
