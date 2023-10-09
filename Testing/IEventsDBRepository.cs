using System;
using System.Collections.Generic;
using System.ComponentModel;
using Testing.Models;


namespace Testing
{
    //Step #8
    public interface IEventsDBRepository
    {

        //Stubbed out method
        public IEnumerable<EventsDB> GetAllEvents();


        public IEnumerable<EventsDB> GetMaliciousEvents();




    }//Interface

    //internal class _conn
    //{
    //    internal static void Execute(string v, object value)
    //    {
    //        throw new NotImplementedException();
    //    }

    //}
}//namespace

