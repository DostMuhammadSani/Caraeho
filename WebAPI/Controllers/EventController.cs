using DALLibrary;
using ClassLibraryModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        // GET: api/Event/BID
        [HttpGet("{BID}")]
        public List<EventModel> GetEventByBranchID(string BID)
        {
            SqlParameter[] p = { new SqlParameter("@BID", BID) };
            return DALClass.GetDataParameter<EventModel>("GetEvent", p);
        }

        // POST: api/Event
        [HttpPost]
        public void InsertEvent(EventModel eventModel)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@EventID", eventModel.EventID),
                new SqlParameter("@EventName", eventModel.EventName),
                new SqlParameter("@EventDescription", eventModel.EventDescription),
                new SqlParameter("@BID", eventModel.BID)
            };
            DALClass.CUD(sp, "CreateEvent");
        }

        // PUT: api/Event
        [HttpPut]
        public void UpdateEvent(EventModel eventModel)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@EventID", eventModel.EventID),
                new SqlParameter("@EventName", eventModel.EventName),
                new SqlParameter("@EventDescription", eventModel.EventDescription)
            };
            DALClass.CUD(sp, "UpdateEvent");
        }

        // DELETE: api/Event/EventID
        [HttpDelete("{EventID}")]
        public void DeleteEvent(string EventID)
        {
            SqlParameter[] sp = { new SqlParameter("@EventID", EventID) };
            DALClass.CUD(sp, "DeleteEvent");
        }
    }
}
