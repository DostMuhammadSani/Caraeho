using DALLibrary;
using ClassLibraryModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodTypeController : ControllerBase
    {
        // GET: api/FoodType/BID
        [HttpGet("{BID}")]
        public List<FoodTypeModel> GetFoodTypeByBranchID(string BID)
        {
            SqlParameter[] p = { new SqlParameter("@BID", BID) };
            return DALClass.GetDataParameter<FoodTypeModel>("GetFoodType", p);
        }

        // POST: api/FoodType
        [HttpPost]
        public void InsertFoodType(FoodTypeModel foodType)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@FoodTypeID", foodType.FoodTypeID),
                new SqlParameter("@FoodTypeName", foodType.FoodTypeName),
                new SqlParameter("@FoodTypeDescription", foodType.FoodTypeDescription),
                new SqlParameter("@BID", foodType.BID)
            };
            DALClass.CUD(sp, "CreateFoodType");
        }

        // PUT: api/FoodType
        [HttpPut]
        public void UpdateFoodType(FoodTypeModel foodType)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@FoodTypeID", foodType.FoodTypeID),
                new SqlParameter("@FoodTypeName", foodType.FoodTypeName),
                new SqlParameter("@FoodTypeDescription", foodType.FoodTypeDescription)
            };
            DALClass.CUD(sp, "UpdateFoodType");
        }

        // DELETE: api/FoodType/FoodTypeID
        [HttpDelete("{FoodTypeID}")]
        public void DeleteFoodType(string FoodTypeID)
        {
            SqlParameter[] sp = { new SqlParameter("@FoodTypeID", FoodTypeID) };
            DALClass.CUD(sp, "DeleteFoodType");
        }
    }
}
