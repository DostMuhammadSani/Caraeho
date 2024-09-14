using DALLibrary;
using ClassLibraryModel.ClassLibraryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClassLibraryModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionController : ControllerBase
    {
        // GET: api/Nutrition/Menu_ID
        [HttpGet("{Menu_ID}")]
        public List<NutritionModel> GetNutritionByMenuID(string Menu_ID)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@Menu_ID", Menu_ID)
            };
            return DALClass.GetDataParameter<NutritionModel>("GetNutrition", p);
        }

        // POST: api/Nutrition
        [HttpPost]
        public void InsertNutrition(NutritionModel nutrition)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@NID", nutrition.NID),
                new SqlParameter("@Title", nutrition.Title),
                new SqlParameter("@Ammount", nutrition.Ammount),
                new SqlParameter("@Menu_ID", nutrition.Menu_ID)
            };
            DALClass.CUD(sp, "InsertNutrition");
        }

        // PUT: api/Nutrition
        [HttpPut]
        public void UpdateNutrition(NutritionModel nutrition)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@NID", nutrition.NID),
                new SqlParameter("@Title", nutrition.Title),
                new SqlParameter("@Ammount", nutrition.Ammount),
                new SqlParameter("@Menu_ID", nutrition.Menu_ID)
            };
            DALClass.CUD(sp, "UpdateNutrition");
        }

        // DELETE: api/Nutrition/NID
        [HttpDelete("{NID}")]
        public void DeleteNutrition(string NID)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@NID", NID)
            };
            DALClass.CUD(sp, "DeleteNutrition");
        }
    }
}
