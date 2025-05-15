using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Domain.Entities;

namespace Demo.Application.Helper
{
    public class ApiResponse<T>
    {
        private bool v1;
        private string v2;
        private int v3;
        private Task<IEnumerable<UsersDetails>> result;

        public bool? IsSuccess { get; set; }
        public string? Message { get; set; }
        public int? StatusCode { get; set; }
        public T? Data { get; set; }

        public ApiResponse(bool isSuccess, string message, int statusCode, T data)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
            this.StatusCode = statusCode;
            this.Data = data;
        }

    }
}
