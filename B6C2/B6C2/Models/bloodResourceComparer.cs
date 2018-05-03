using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B6C2.Models
{
    public class BloodResourceComparer : IEqualityComparer<bloodResource>
    {
         
        public bool Equals(bloodResource x, bloodResource y)
        {
            return (x.idBlood.Equals(y.idBlood)&& x.idCenter.Equals(y.idCenter)  );
        }


        public int GetHashCode(bloodResource obj)
        {
            return string.Format("{0}{1}", obj.idCenter, obj.idBlood).GetHashCode();
        }
    }
    }
