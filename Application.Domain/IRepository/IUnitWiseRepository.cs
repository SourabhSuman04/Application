using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain.Entities;

namespace Application.Domain.IRepository
{
    public interface IUnitWiseRepository
    {
        public Task<IEnumerable<UnitWise>> getAllRecords();

        Task<string> UploadUsers(DataTable users);

        public Task<IEnumerable<XBucketUnitwise>> getAllXbucketRecords();
    }
}
