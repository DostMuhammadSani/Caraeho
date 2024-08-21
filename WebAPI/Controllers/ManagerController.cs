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
    public class ManagerController : ControllerBase
    {
        [HttpGet]
        public List<ManagerModel> GetManagers(string PID)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@PID", PID)
            };
            return DALClass.GetDataParameter<ManagerModel>("SelectManagers", p);
        }

        [HttpGet("CompanyMail")]
        public List<EmailModel> GetManagersMail(string CID)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@CID", CID)
            };
            return DALClass.GetDataParameter<EmailModel>("GetMailCompany", p);
        }
        [HttpGet("CompanyBranch")]
        public List<EmailModel> GetManagersMailBranch(string BID)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@BID", BID)
            };
            return DALClass.GetDataParameter<EmailModel>("GetMailBranch", p);
        }
        [HttpPost]
        public void InsertManager(ManagerModel manager)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@MID", manager.MID),
                new SqlParameter("@MName", manager.MName),
                new SqlParameter("@Email", manager.Email),
                new SqlParameter("@Contact", manager.Contact),
                new SqlParameter("@BID", manager.BID)
            };
            DALClass.CUD(sp, "InsertManager");
        }

        [HttpPut]
        public void UpdateManager(ManagerModel manager)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@MID", manager.MID),
                new SqlParameter("@MName", manager.MName),
                new SqlParameter("@Email", manager.Email),
                new SqlParameter("@Contact", manager.Contact)
            };
            DALClass.CUD(sp, "UpdateManagers");
        }

        [HttpDelete]
        public void DeleteManager(string MID)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@MID", MID)
            };
            DALClass.CUD(sp, "DeleteManager");
        }
    }
}
