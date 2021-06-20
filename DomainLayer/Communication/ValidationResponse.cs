using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Communication
{
    public class ValidationResponse
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public ValidationResponse(string message)
        {
            Success = false;
            Message = message;
        }

        public ValidationResponse()
        {
            Success = true;
            Message = "";
        }
    }
}
