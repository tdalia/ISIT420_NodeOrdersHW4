using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NodeOrders500_HW4.Models
{
    public class CityCDCount
    {
        public CityCDCount(string cityName, int cdId, int count)
        {
            CityName = cityName;
            CDId = cdId;
            CDCount = count;
        }
        public string CityName { get; set; }

        public int CDCount { get; set; }

        public int CDId { get; set; }
    }
}