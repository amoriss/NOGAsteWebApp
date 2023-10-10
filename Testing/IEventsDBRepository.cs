using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using NOGAsteWebApp.Models;


namespace NOGAsteWebApp
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
        public void UpdateEvent(EventsDBModel updEvent);

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

