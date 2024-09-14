using DALLibrary;
using ClassLibraryModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using ClassLibraryModel.ClassLibraryModel;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        // GET: api/Menu/Cat_ID
        [HttpGet("{Cat_ID}")]
        public List<MenuModel> GetMenu(string Cat_ID)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@Cat_ID", Cat_ID)
            };
            return DALClass.GetDataParameter<MenuModel>("GetMenu", p);
        }

        // POST: api/Menu
        [HttpPost]
        public void InsertMenu(MenuModel menu)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@Menu_ID", menu.Menu_ID),
                new SqlParameter("@Item", menu.Item),
                new SqlParameter("@Quantity", menu.Quantity),
                new SqlParameter("@Serving", menu.Serving),
                new SqlParameter("@Price", menu.Price),
                new SqlParameter("@Cat_ID", menu.Cat_ID)
            };
            DALClass.CUD(sp, "InsertMenu");
        }

        // PUT: api/Menu
        [HttpPut]
        public void UpdateMenu(MenuModel menu)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@Menu_ID", menu.Menu_ID),
                new SqlParameter("@Item", menu.Item),
                new SqlParameter("@Quantity", menu.Quantity),
                new SqlParameter("@Serving", menu.Serving),
                new SqlParameter("@Price", menu.Price),
                new SqlParameter("@Cat_ID", menu.Cat_ID)
            };
            DALClass.CUD(sp, "UpdateMenu");
        }

        // DELETE: api/Menu/Menu_ID
        [HttpDelete("{Menu_ID}")]
        public void DeleteMenu(string Menu_ID)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@Menu_ID", Menu_ID)
            };
            DALClass.CUD(sp, "DeleteMenu");
        }
    }
}
