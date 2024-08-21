using ClassLibraryModel;
using DALLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpPost]
        public void Save(PersonModel p)
        {
            SqlParameter[] parameters = new SqlParameter[] {

             new SqlParameter ("@Id", p.Id),
            new SqlParameter("@Name", p.Name),
            new SqlParameter ("@Email", p.Email),
            new SqlParameter ("@Phone", p.Phone)
        };
            DALClass.CUD(parameters, "SavePerson");

        

        }


        [HttpGet("ID")]
        public string GetID(string Email)
        {
          
            return DALClass.GetID(Email);
        }


      
    }
}
