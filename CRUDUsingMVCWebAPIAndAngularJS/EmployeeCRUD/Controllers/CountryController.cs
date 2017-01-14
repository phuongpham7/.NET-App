using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace EmployeeCRUD.Controllers
{
    public class CountryController : ApiController
    {
        // GET: api/country
        public IEnumerable<SelectListItem> GetCountries()
        {
            List<SelectListItem> countries = new List<SelectListItem>()
            {
                new SelectListItem { Text = "United States", Value = "US" }
            };
            return countries;
        }

        // GET: api/country/US
        public IEnumerable<SelectListItem> GetStatesByCountry(string id)
        {
            List<SelectListItem> states = new List<SelectListItem>();
            switch (id)
            {
                case "US":
                case "us":
                    states.Add(new SelectListItem { Text = "Illinois", Value = "IL" });
                    states.Add(new SelectListItem { Text = "California", Value = "CA" });
                    states.Add(new SelectListItem { Text = "Nevada", Value = "NV" });
                    break;
            }
            return states;
        }
    }
}
