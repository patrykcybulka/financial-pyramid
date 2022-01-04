using financial_pyramid.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financial_pyramid.Exceptions
{
    public class FinancialPyramidException : Exception 
    {
        public FinancialPyramidException(EErrorCode errorCode ) : base("Code: " + errorCode)
        {
        }
    }
}
