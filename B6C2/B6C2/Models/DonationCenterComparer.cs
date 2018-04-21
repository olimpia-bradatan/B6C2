using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B6C2.Models
{
    public class DonationCenterComparer : IEqualityComparer<donationCenter>
    {
        public bool Equals(donationCenter x, donationCenter y)
        {
            return x.address.Equals(y.address);
        }

        public int GetHashCode(donationCenter obj)
        {
            return string.Format("{0}{1}{2}", obj.name, obj.address).GetHashCode();
        }
    }
}