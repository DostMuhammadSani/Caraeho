using DALLibrary;
using ClassLibraryModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuisineController : ControllerBase
    {
        // GET: api/Cuisine/BID
        [HttpGet("{BID}")]
        public List<CuisineModel> GetCuisineByBranchID(string BID)
        {
            SqlParameter[] p = { new SqlParameter("@BID", BID) };
            return DALClass.GetDataParameter<CuisineModel>("GetCuisine", p);
        }

        // POST: api/Cuisine
        [HttpPost]
        public void InsertCuisine(CuisineModel cuisine)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@CuisineID", cuisine.CuisineID),
                new SqlParameter("@CuisineName", cuisine.CuisineName),
                new SqlParameter("@CuisineDescription", cuisine.CuisineDescription),
                new SqlParameter("@BID", cuisine.BID)
            };
            DALClass.CUD(sp, "CreateCuisine");
        }

        // PUT: api/Cuisine
        [HttpPut]
        public void UpdateCuisine(CuisineModel cuisine)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@CuisineID", cuisine.CuisineID),
                new SqlParameter("@CuisineName", cuisine.CuisineName),
                new SqlParameter("@CuisineDescription", cuisine.CuisineDescription)
            };
            DALClass.CUD(sp, "UpdateCuisine");
        }

        // DELETE: api/Cuisine/CuisineID
        [HttpDelete("{CuisineID}")]
        public void DeleteCuisine(string CuisineID)
        {
            SqlParameter[] sp = { new SqlParameter("@CuisineID", CuisineID) };
            DALClass.CUD(sp, "DeleteCuisine");
        }
    }
}
