using Dapper;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Testing.Models;

namespace Testing
{
    //Step #9
    public class EventsDBRepository : IEventsDBRepository
    {

        //field
        private readonly IDbConnection _conn;

        //Constructor
        public EventsDBRepository(IDbConnection conn)
        {

            _conn = conn;

        }


 

        //Method
        public IEnumerable<EventsDB> GetAllEvents()
        {
            return _conn.Query<EventsDB>("SELECT * from events;");
        }
    }//class
}//namespace
