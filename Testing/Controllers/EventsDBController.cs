using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Testing.Models;

namespace Testing.Controllers
{
    public class EventsDBController : Controller
    {
        private readonly IEventsDBRepository repo;

        public EventsDBController(IEventsDBRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var events = repo.GetAllEvents();
            return View(events);
        }

        public IActionResult GetMaliciousEvents()
        {

        var events = repo.GetMaliciousEvents();
            return View(events);
        }
        



    }//class
}//namespace
