using ClassLibraryModel;
using DALLibrary;
using FrontEndLoginSignUp.Components.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        [HttpGet]
        public  List<CompanyModel> GetCompany(string PID)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@PID",PID)
            };
            return  DALClass.GetDataParameter<CompanyModel>("GetCompanyPerson",  p);
        }
        [HttpGet("CID")]
        public  string GetCompanyID(string CName)
        {
          return DALClass.GetCID(CName);
        }
        [HttpPost]

        public void SaveCompany(CompanyModel company)
        {
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter ("@CID",company.CID),
            new SqlParameter ("@CName",company.CName),
            new SqlParameter ("@City",company.City),
            new SqlParameter ("@PID",company.PID)
            };
            DALClass.CUD(sp, "SaveCompany");
        }

        [HttpPut]
        public void UpdateCompany(CompanyModel company )
        {
            SqlParameter[] sp = new SqlParameter[] {
            new SqlParameter ("@CID",company.CID),
            new SqlParameter ("@CName",company.CName),
            new SqlParameter ("@City",company.City),
           
            };
            DALClass.CUD(sp, "UpdateCompany");
        }

        [HttpDelete]
        public void DeleteCompany(string CID)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter ("@CID",CID)
            };
            DALClass.CUD(sp, "DeleteCompany");

        }
    }
}
