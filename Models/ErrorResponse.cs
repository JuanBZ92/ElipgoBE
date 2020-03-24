using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElipgoBE.Models
{
    public class ErrorResponse
    {
        public bool Success { get; set; }
        public int Error_Code { get; set; }
        public string Error_Message { get; set; }
        
        public static ErrorResponse Map(Exception e)
        {
            return new ErrorResponse
            {
                Success = false,
                Error_Message = e.Message,
                Error_Code = e.HResult
            };
        }
    }
}
