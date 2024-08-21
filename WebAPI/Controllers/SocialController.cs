using ClassLibraryModel;
using DALLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialController : ControllerBase
    {
        [HttpPost]
        public void SaveSocial(SocialModel S)
        {
            SqlParameter[] sqlParameter ={
            new SqlParameter("@CID",S.CID),
            new SqlParameter("@Website",S.Website),
            new SqlParameter("@Facebook",S.Facebook),
            new SqlParameter("@Instagram",S.Instagram)
            };
            DALClass.CUD(sqlParameter, "SaveSocial");
        }

        [HttpPut]
        public void UpdateSocial(SocialModel S)
        {
            SqlParameter[] sqlParameter ={
            new SqlParameter("@CID",S.CID),
            new SqlParameter("@Website",S.Website),
            new SqlParameter("@Facebook",S.Facebook),
            new SqlParameter("@Instagram",S.Instagram)
            };
            DALClass.CUD(sqlParameter, "UpdateSocial");
        }

    }
}
