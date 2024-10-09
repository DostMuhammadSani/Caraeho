using DALLibrary;
using ClassLibraryModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatingController : ControllerBase
    {
        // GET: api/Seating/BID
        [HttpGet("{BID}")]
        public List<SeatingModel> GetSeatingByBranchID(string BID)
        {
            SqlParameter[] p = { new SqlParameter("@BID", BID) };
            return DALClass.GetDataParameter<SeatingModel>("GetSeating", p);
        }

        // POST: api/Seating
        [HttpPost]
        public void InsertSeating(SeatingModel seating)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@SeatingID", seating.SeatingID),
                new SqlParameter("@SeatingType", seating.SeatingType),
                new SqlParameter("@BID", seating.BID)
            };
            DALClass.CUD(sp, "CreateSeating");
        }

        // PUT: api/Seating
        [HttpPut]
        public void UpdateSeating(SeatingModel seating)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@SeatingID", seating.SeatingID),
                new SqlParameter("@SeatingType", seating.SeatingType)
            };
            DALClass.CUD(sp, "UpdateSeating");
        }

        // DELETE: api/Seating/SeatingID
        [HttpDelete("{SeatingID}")]
        public void DeleteSeating(string SeatingID)
        {
            SqlParameter[] sp = { new SqlParameter("@SeatingID", SeatingID) };
            DALClass.CUD(sp, "DeleteSeating");
        }
    }
}
