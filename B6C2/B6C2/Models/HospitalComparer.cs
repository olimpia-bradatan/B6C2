using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B6C2.Models
{
    public class HospitalComparer : IEqualityComparer<Hospital>
    {
        public bool Equals(Hospital x, Hospital y)
        {
            return x.name.Equals(y.name) && x.address.Equals(y.address);
        }

        public int GetHashCode(Hospital obj)
        {
            return string.Format("{0}{1}", obj.name, obj.address).GetHashCode();
            
        }
    }
}