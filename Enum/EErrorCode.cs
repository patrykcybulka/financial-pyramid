using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financial_pyramid.Enum
{
    public enum EErrorCode
    {
        Unknown = 0,
        InvalidIdRange = 1,
        IncorrectPyramidLevelRange = 2,
        InvalidNumberOfSubordinatesWithNoSubordinates = 3,
        IncorrectCommissionRange = 4,
        CompanyMemberNotExit = 5,
        InvalidAmount = 6
    }
}
