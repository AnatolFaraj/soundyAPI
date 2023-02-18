using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class CustomResponseException : Exception
    {
        public string ErrorDescription { get; set; }
        public int StatusCode { get; set; }
        public CustomResponseException()
        {

        }
    }
}
