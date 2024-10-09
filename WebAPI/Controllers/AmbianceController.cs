using DALLibrary;
using ClassLibraryModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmbianceController : ControllerBase
    {
        // GET: api/Ambiance/BID
        [HttpGet("{BID}")]
        public List<AmbianceModel> GetAmbianceByBranchID(string BID)
        {
            SqlParameter[] p = { new SqlParameter("@BID", BID) };
            return DALClass.GetDataParameter<AmbianceModel>("GetAmbiance", p);
        }

        // POST: api/Ambiance
        [HttpPost]
        public void InsertAmbiance(AmbianceModel ambiance)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@AmbianceID", ambiance.AmbianceID),
                new SqlParameter("@AmbianceName", ambiance.AmbianceName),
                new SqlParameter("@AmbianceDescription", ambiance.AmbianceDescription),
                new SqlParameter("@BID", ambiance.BID)
            };
            DALClass.CUD(sp, "CreateAmbiance");
        }

        // PUT: api/Ambiance
        [HttpPut]
        public void UpdateAmbiance(AmbianceModel ambiance)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@AmbianceID", ambiance.AmbianceID),
                new SqlParameter("@AmbianceName", ambiance.AmbianceName),
                new SqlParameter("@AmbianceDescription", ambiance.AmbianceDescription)
            };
            DALClass.CUD(sp, "UpdateAmbiance");
        }

        // DELETE: api/Ambiance/AmbianceID
        [HttpDelete("{AmbianceID}")]
        public void DeleteAmbiance(string AmbianceID)
        {
            SqlParameter[] sp = { new SqlParameter("@AmbianceID", AmbianceID) };
            DALClass.CUD(sp, "DeleteAmbiance");
        }
    }
}
