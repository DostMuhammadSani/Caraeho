using DALLibrary;
using ClassLibraryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {
        // GET: api/Ingredient/Menu_ID
        [HttpGet("{Menu_ID}")]
        public List<IngredientModel> GetIngredientsByMenuID(string Menu_ID)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@Menu_ID", Menu_ID)
            };
            return DALClass.GetDataParameter<IngredientModel>("GetIngredientsByMenuID", p);
        }

        // POST: api/Ingredient
        [HttpPost]
        public void InsertIngredient(IngredientModel ingredient)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@IID", ingredient.IID),
                new SqlParameter("@Title", ingredient.Title),
                new SqlParameter("@Ammount", ingredient.Ammount),
                new SqlParameter("@Menu_ID", ingredient.Menu_ID)
            };
            DALClass.CUD(sp, "InsertIngredient");
        }

        // PUT: api/Ingredient
        [HttpPut]
        public void UpdateIngredient(IngredientModel ingredient)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@IID", ingredient.IID),
                new SqlParameter("@Title", ingredient.Title),
                new SqlParameter("@Ammount", ingredient.Ammount),
                new SqlParameter("@Menu_ID", ingredient.Menu_ID)
            };
            DALClass.CUD(sp, "UpdateIngredient");
        }

        // DELETE: api/Ingredient/IID
        [HttpDelete("{IID}")]
        public void DeleteIngredient(string IID)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@IID", IID)
            };
            DALClass.CUD(sp, "DeleteIngredient");
        }
    }
}
