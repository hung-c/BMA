using System;
using System.Collections.Generic;
using System.Text;

namespace BMA_Database.Models
{
    public class Contain
    {
        public DateTime order_date { get; set; }
        public int order_number { get; set; }
        public int menu_number { get; set; }
        public string note { get; set; }
        public int bill { get; set; }
    }
}
