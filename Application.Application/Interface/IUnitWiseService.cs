using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain.Entities;
using Demo.Application.Helper;
using Microsoft.AspNetCore.Http;

namespace Application.Application.Interface
{
    public interface IUnitWiseService
    {
        Task<ApiResponse<IEnumerable<UnitWise>>> getAllRecords();

        Task<ApiResponse<IEnumerable<XBucketUnitwise>>> getXbucketAllRecords();
        Task<object> ImportOdnpaFromExcelAsync(IFormFile file);
    }
}
