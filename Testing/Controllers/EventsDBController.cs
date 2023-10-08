﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
            var products = repo.GetAllEvents();
            return View(products);
        }

  




    }//class
}//namespace