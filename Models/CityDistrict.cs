using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AydinogluLavender.Models
{
    public class CityDistrict
    {
        public IEnumerable<SelectListItem> Cities { get; set; }
        public IEnumerable<SelectListItem> Districts { get; set; }
    }
}