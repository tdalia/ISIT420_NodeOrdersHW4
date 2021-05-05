using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NodeOrders500_HW4.Models
{
    public class StoreDTO
    {
        public StoreDTO()
        {

        }
        public StoreDTO(int id, string city)
        {
            StoreId = id;
            City = city;
        }
        public int StoreId { get; set; }

        public string City { get; set; }
    }
}