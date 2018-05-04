using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineFoodOrderManagment.Models
{
    public class Restaurant
    {
        public int restaurantID1{ get; set; }
        public string restaurantname { get; set; }
        public Nullable<int> fooditemid { get; set; }
    }
}