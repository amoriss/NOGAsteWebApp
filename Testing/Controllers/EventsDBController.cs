using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NOGAsteWebApp.Models;

namespace NOGAsteWebApp.Controllers
{
    public class EventsDBController : Controller
    {
        private readonly IEventsDBRepository repo;

        public EventsDBController(IEventsDBRepository repo)
        {
            this.repo = repo;
        }//EventsDBControlle

        //---------------------------------
        //There is no View "GetAllEvents" that is
        //handled by EventsDB.Index.cshtml
        public IActionResult Index()
        {
            var eventList = repo.GetAllEvents();
            return View(eventList);
        }//GetAllEvents

        //---------------------------------
        public IActionResult GetProhibitedEvents()  //creates the view
        {
           var malEvents = repo.GetMaliciousEvents(); //gets the data
            return View(malEvents);
        }//GetProhibitedEvents


        //---------------------------------
        public IActionResult ViewEvent(int id) //creates the view
        {
            EventsDBModel eventsDBModelObj = repo.GetEvent(id); //returns an "EventsDBModel" object
            //int keyID = eventsDBModelObj.KeyID;
            //return View(keyID);
            return View(eventsDBModelObj); 
        }//ViewEvent


        //---------------------------------
        public IActionResult UpdateEventToDatabase(EventsDBModel updEventToDB)
        {
            repo.UpdateEventInDB(updEventToDB);

            return RedirectToAction("ViewEvent", new { id = updEventToDB.KeyID });
        }//UpdateEventToDatabase


        //---------------------------------
        public IActionResult UpdateEvent(int KeyID) //creates the view
        {
            EventsDBModel updEvent = repo.GetEvent(KeyID); //get the data

            if (updEvent == null)
            {
                return View("EventNotFound"); //creates error response view
            }
            return View(updEvent);
         }//UpdateEventInDB
    


    }//class
}//namespace
