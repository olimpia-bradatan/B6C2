using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B6C2.Models
{
    public class CenterEmployeeComparer : IEqualityComparer<centerEmployee>
    {
        public bool Equals(centerEmployee x, centerEmployee y)
        {
            return x.firstName.Equals(y.firstName) && x.lastName.Equals(y.lastName) && x.email.Equals(y.email);
        }

        public int GetHashCode(centerEmployee obj)
        {
            return string.Format("{0}{1}{2}", obj.firstName, obj.lastName, obj.email).GetHashCode();
        }
    }
}