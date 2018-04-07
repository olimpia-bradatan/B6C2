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
            return x.firstName.Equals(y.firstName) && x.lastName.Equals(y.lastName) && x.birthDate.Equals(y.birthDate);
        }

        public int GetHashCode(Donor obj)
        {
            return string.Format("{0}{1}{2}", obj.idDonor, obj.firstName, obj.lastName).GetHashCode();
        } 
    }
}