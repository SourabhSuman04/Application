using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain.Entities;
using Application.Domain.IRepository;
using Dapper;

namespace Application.DataAccess.Repository
{
    public class UnitWiseRepository : IUnitWiseRepository
    {
        public readonly IDbConnection dbconnection;
        public UnitWiseRepository(IDbConnection _dbconnection) 
        {
            dbconnection = _dbconnection;
        }

    



        public async Task<IEnumerable<UnitWise>> getAllRecords()
        {
            try
            {
                return await dbconnection.QueryAsync<UnitWise>("GetAllUnitWiseRecords");
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<IEnumerable<XBucketUnitwise>> getAllXbucketRecords()
        {
            try
            {
                //var sql = "select[RM/BH],Funder,[State],[Unit],[X Bucket flow clients],[Visits on X bucket],[Unique Visits on X bucket],Reduced,Collected,Collected Amount from XBucketUnitwise";
                var res= await dbconnection.QueryAsync<XBucketUnitwise>("getXbucketUnitwiserecord");
                return res;
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public async Task<string> UploadUsers(DataTable users)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
          
                param.Add("@Odnpadata", users.AsTableValuedParameter("dbo.odNPAA_TVP"));

                var data= this.dbconnection.QueryFirstOrDefault<string>("UploadUsers @Odnpadata", param);
                return data;
            }
            catch
            {
                throw;
            }
        }
    }
}
