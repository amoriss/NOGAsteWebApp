using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using NOGAsteWebAPP.Models;


namespace NOGAsteWebAPP
{
    //Step #8
    public interface IEventsDBRepository
    {

        //Stubbed out methods
        //-----------------------
        public IEnumerable<EventsDBModel> GetAllEvents();

        //-----------------------
        public EventsDBModel GetEvent(int id);

        //-----------------------
        public void UpdateEventInDB(EventsDBModel updEvent);

        //-----------------------
        public IEnumerable<EventsDBModel> GetMaliciousEvents();


        //-----------------------
        //public void DeleteProduct(Product product);

    }//Interface

    //internal class _conn
    //{
    //    internal static void Execute(string v, object value)
    //    {
    //        throw new NotImplementedException();
    //    }

    //}
}//namespace

