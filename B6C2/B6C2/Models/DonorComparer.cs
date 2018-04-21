using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B6C2.Models
{
    public class DonorComparer : IEqualityComparer<Donor>
    {
        public bool Equals(Donor x, Donor y)
        {
            return x.cnp.Equals(y.cnp);
        }

        public int GetHashCode(Donor obj)
        {
            return string.Format("{0}{1}{2}", obj.cnp, obj.firstName, obj.lastName).GetHashCode();
        } 
    }
}