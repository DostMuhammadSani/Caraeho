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
    public class CategoryController : ControllerBase
    {
        // GET: api/Category/BID
        [HttpGet("{BID}")]
        public List<CategoryModel> GetCategories(string BID)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@BID", BID)
            };
            return DALClass.GetDataParameter<CategoryModel>("GetCategory", p);
        }

        // POST: api/Category
        [HttpPost]
        public void InsertCategory(CategoryModel category)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@Cat_ID", category.Cat_ID),
                new SqlParameter("@Title", category.Title),
                new SqlParameter("@BID", category.BID)
            };
            DALClass.CUD(sp, "InsertCategory");
        }

        // PUT: api/Category
        [HttpPut]
        public void UpdateCategory(CategoryModel category)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@Cat_ID", category.Cat_ID),
                new SqlParameter("@Title", category.Title),
                new SqlParameter("@BID", category.BID)
            };
            DALClass.CUD(sp, "UpdateCategory");
        }

        // DELETE: api/Category/Cat_ID
        [HttpDelete("{Cat_ID}")]
        public void DeleteCategory(string Cat_ID)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@Cat_ID", Cat_ID)
            };
            DALClass.CUD(sp, "DeleteCategory");
        }
    }
}
