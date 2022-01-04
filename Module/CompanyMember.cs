using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace financial_pyramid.Module
{
    public class CompanyMember
    {
        public int Id { get; set; }
       
        public int PyramidLevel { get; set; }

        public IEnumerable<int> IdentifiersOfSuperiors { get; set; }

        public int NumberOfSubordinatesWithoutSubordinates { get; set; }

        public int Amount { get; set; }
    }
}
