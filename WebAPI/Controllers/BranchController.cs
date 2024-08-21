using ClassLibraryModel;
using DALLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        [HttpGet]
        public List<BranchModel> GetBranch(string PID)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@PID",PID)
            };
            return DALClass.GetDataParameter<BranchModel>("GetBranchPersons", p);
        }

        [HttpGet("Manager")]
        public List<BranchModel> GetBranchManager(string Email)
        {
            SqlParameter[] p =
            {
                new SqlParameter("@Email",Email)
            };
            return DALClass.GetDataParameter<BranchModel>("GetBranchManager", p);
        }
     

        [HttpPost]
        public void SaveBranch(BranchModel branch)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@BID", branch.BID),
                new SqlParameter("@BName", branch.BName),
                new SqlParameter("@BAddress", branch.BAddress),
                new SqlParameter("@City", branch.City),
                new SqlParameter("@CID", branch.CID)
            };
            DALClass.CUD(sp, "SaveBranch");
        }

        [HttpPut]
        public void UpdateBranch(BranchModel branch)
        {
            SqlParameter[] sp = new SqlParameter[] {
                new SqlParameter("@BID", branch.BID),
                new SqlParameter("@BName", branch.BName),
                new SqlParameter("@BAddress", branch.BAddress),
                new SqlParameter("@City", branch.City)
            };
            DALClass.CUD(sp, "UpdateBranch");
        }

        [HttpDelete]
        public void DeleteBranch(string BID)
        {
            SqlParameter[] sp = new SqlParameter[]
            {
                new SqlParameter("@BID", BID)
            };
            DALClass.CUD(sp, "DeleteBranch");
        }
    }
}
