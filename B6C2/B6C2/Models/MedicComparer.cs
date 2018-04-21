using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B6C2.Models
{
    public class MedicComparer : IEqualityComparer<Medic>
    {
        public bool Equals(Medic x, Medic y)
        {
            return x.firstName.Equals(y.firstName) && x.lastName.Equals(y.lastName);
        }

        public int GetHashCode(Medic obj)
        {
            return string.Format("{0}{1}", obj.firstName,obj.lastName).GetHashCode();
        }

    }
}