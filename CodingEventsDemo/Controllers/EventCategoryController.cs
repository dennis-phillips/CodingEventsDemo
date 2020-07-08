using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingEventsDemo.Data;
using CodingEventsDemo.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using CodingEventsDemo.ViewModels;

namespace CodingEventsDemo.Controllers
{

    public class EventCategoryController : Controller
    {
        private EventDbContext context;

        public EventCategoryController(EventDbContext dbContext)
        {
            context = dbContext;
        }



        public IActionResult Index()
        {
            ViewBag.title = "All Categories";
            List<EventCategory> categories = context.Categories.ToList();
            return View(categories);
        }


        public IActionResult Create()
        {
            AddEventCategoryViewModel eventCategory = new AddEventCategoryViewModel();

            return View(eventCategory);
        }

        [HttpPost]
        public IActionResult ProcessCreate(AddEventCategoryViewModel addEventCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                EventCategory eventCategory = new EventCategory
                {
                    Name = addEventCategoryViewModel.Name
                };
                context.Categories.Add(eventCategory);
                context.SaveChanges();
                return Redirect("/EventCategory/Index");
            }
            return View("Create", addEventCategoryViewModel);

        }
    }
}
