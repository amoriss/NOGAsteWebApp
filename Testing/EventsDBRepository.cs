using Dapper;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using NOGAsteWebAPP.Models;

namespace NOGAsteWebAPP
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


        public void DeleteEvents(EventsDBModel tgtEvent)
        {
           _conn.Execute("DELETE FROM securityLogs.events " +
                " WHERE ThreatEval = @id;", new { id = tgtEvent });
        }
        //Method


        //Method
        public IEnumerable<EventsDBModel> GetAllEvents()
        {
           return _conn.Query<EventsDBModel>("SELECT * from securityLogs.events;");
        }

        public EventsDBModel GetEvent(int tgtKeyID)
        {
           return _conn.QuerySingleOrDefault<EventsDBModel>("SELECT KeyID FROM " +
                " securityLogs.events WHERE KeyID = @KeyID", new { KeyID = tgtKeyID });
        }

        public IEnumerable<EventsDBModel> GetMaliciousEvents()
        {
           return _conn.Query<EventsDBModel>("SELECT * FROM securityLogs.events WHERE " +
                                         " CommandRun  LIKE '%powershell%' OR " +
                                         " ProcessInfo LIKE '%powershell%' OR " + 
                                         " ObjName     LIKE '%powershell%' OR " +
                                         " AppPath     LIKE '%powershell%' ;  "
                                         );
        }


        public void UpdateEventInDB(EventsDBModel keyIdOfEventToBeUpdated)
        {
            _conn.Execute("UPDATE events SET securityLogs.ThreatEval = @threatEval WHERE KeyID = @id",
             new { threatEval = keyIdOfEventToBeUpdated.ThreatEval, id = keyIdOfEventToBeUpdated.KeyID });
        }


    }//class
}//namespace
