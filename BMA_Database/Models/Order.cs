using System;
using System.Collections.Generic;
using System.Text;

namespace BMA_Database.Models
{
    public class Order
    {
        public DateTime date { get; set; }     //key 1/2
        public int order_number { get; set; }  //key 2/2
        public string order_type { get; set; }
    }
}
