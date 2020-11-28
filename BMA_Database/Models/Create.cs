using System;
using System.Collections.Generic;
using System.Text;

namespace BMA_Database.Models
{
    public class Create
    {
        public string account_username { get; set; }
        public DateTime order_date { get; set; }
        public int order_number { get; set; }
    }
}
