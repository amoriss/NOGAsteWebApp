using Dapper;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using NOGAsteWebApp.Models;
using MySql.Data.MySqlClient;

namespace NOGAsteWebApp
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

        //-----------------------
        //AssignCategory - NOT USED


        //-----------------------
        //public void DeleteEvents(EventsDBModel tgtEventKeyID)
        //{
        //   _conn.Execute("DELETE FROM securityLogs.events " +
        //        " WHERE ThreatEval = @id;", new { id = tgtEventKeyID });
        //}



        //-----------------------
        public IEnumerable<EventsDBModel> GetAllEvents()
        {
           return _conn.Query<EventsDBModel>("SELECT * from securityLogs.events;");
        }

        public EventsDBModel GetEvent(int tgtKeyID)
        {
            //returns an "EventsDBModel" object
                //return _conn.QuerySingle<Product>("SELECT * FROM PRODUCTS WHERE PRODUCTID = @id", new { id = id });
            return _conn.QuerySingle<EventsDBModel>("SELECT * FROM events   WHERE KeyID = @perpID", new {perpID = tgtKeyID });
        }

        //public EventsDBModel GetEvent(int tgtKeyID)
        //{
        //  //returns an "EventsDBModel" object
        //  return _conn.QuerySingle<EventsDBModel>("SELECT " +
        //     " KeyID,EventID,TimeCreated,UserID,ThreatEval,ActionReqd FROM " +
        //     " securityLogs.events WHERE KeyID = @perpID", new {perpID = tgtKeyID });
        //}


        //------------------------
        //InsertProduct - NOT USED


        //------------------------
        //GetCategories - NOT USED






        //-----------------------
        public void UpdateEvent(EventsDBModel keyIdOfEventToBeUpdated)
        {
            //_conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
            //     new { name = product.Name, price = product.Price, id = product.ProductID
            //});
            //_conn.Execute("UPDATE securityLogs.events SET securityLogs.ThreatEval = @threatEval WHERE KeyID = @id",
            // new { threatEval = keyIdOfEventToBeUpdated.ThreatEval, id = keyIdOfEventToBeUpdated.KeyID });
            _conn.Execute("UPDATE securityLogs.events SET securityLogs.ThreatEval = @threatEval WHERE KeyID = @id",
            new { threatEval = keyIdOfEventToBeUpdated.ThreatEval });
        }

        //-----------------------
        public IEnumerable<EventsDBModel> GetMaliciousEvents()
        {
            return _conn.Query<EventsDBModel>("SELECT " +
                " KeyID,EventID,UserID,CommandRun,ProcessInfo,ObjName,AppPath " +
                " FROM securityLogs.events WHERE " +
                " CommandRun  LIKE '%powershell%' OR " +
                " ProcessInfo LIKE '%powershell%' OR " +
                " ObjName     LIKE '%powershell%' OR " +
                " AppPath     LIKE '%powershell%' ;  "
                 );
        }


    }//class
}//namespace
