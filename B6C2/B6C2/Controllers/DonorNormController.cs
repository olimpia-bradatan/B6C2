using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace B6C2.Controllers
{
    public class DonorNormController : Controller
    {

        ISSContext db = new ISSContext();



        // GET: DonorNorm/Edit/5
        public ActionResult DonorNormIndex( String id)
        {
            List<Donor> donor = new List<Donor>();
            List<Donor> donorbun = new List<Donor>();


            for (int i = 0; i < db.Donors.Count(); i++)
            {
                donor.Add(db.Donors.ToList().ElementAt(i));
            }



            List<String> cordH = new List<String>();

            while (cordH.Count == 0)
            {
                cordH.Clear();
                cordH = GetLatLng(db.donationCenters.ToList().ElementAt(Int32.Parse(id)).address);

            }

            for (int i = 0; i < donor.Count; i++)
            {

                List<String> cordD = new List<String>();

                while (cordD.Count == 0)
                {
                    cordD.Clear();
                    cordD = GetLatLng(donor.ElementAt(i).address);
                }


                //1
                if (Norm(Convert.ToDouble(cordH.ToList().ElementAt(0)), Convert.ToDouble(cordH.ToList().ElementAt(1)), Convert.ToDouble(cordD.ToList().ElementAt(0)), Convert.ToDouble(cordD.ToList().ElementAt(1))) < 10)
                {
                    Console.WriteLine(Norm(Convert.ToDouble(cordH.ToList().ElementAt(0)), Convert.ToDouble(cordH.ToList().ElementAt(1)), Convert.ToDouble(cordD.ToList().ElementAt(0)), Convert.ToDouble(cordD.ToList().ElementAt(1))));
                    donorbun.Add(donor.ElementAt(i));
                }
            }


            return View(donorbun.ToList());
        }

        [HttpPost]
        public ActionResult MyAction(string button)
        {
            return View("TestView");
        }
        public static double Norm(double lat1, double lon1, double lat2, double lon2)
        {
            double rlat1 = Math.PI * lat1 / 180;
            double rlat2 = Math.PI * lat2 / 180;
            double theta = lon1 - lon2;
            double rtheta = Math.PI * theta / 180;
            double dist =
                Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;



            return dist * 1.609344;

        }
        public static List<String> GetLatLng(string address)
        {
            var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=true", Uri.EscapeDataString(address));
            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());
            var latLngArray = new List<String>();
            var xElement = xdoc.Element("GeocodeResponse");
            if (xElement != null)
            {

                var result = xElement.Element("result");
                if (result != null)
                {

                    var element = result.Element("geometry");
                    if (element != null)
                    {
                        var locationElement = element.Element("location");
                        if (locationElement != null)
                        {
                            var xElement1 = locationElement.Element("lat");
                            if (xElement1 != null)
                            {
                                var lat = xElement1.Value;
                                latLngArray.Add(lat);
                            }
                            var element1 = locationElement.Element("lng");
                            if (element1 != null)
                            {
                                var lng = element1.Value;
                                latLngArray.Add(lng);
                            }
                        }
                    }
                }
            }
            return latLngArray;
        }


    }
}
