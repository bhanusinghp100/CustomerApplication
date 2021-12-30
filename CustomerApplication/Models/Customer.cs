using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApplication.Models
{
    public interface Customer
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public double CustomerAmount { get; set; } 

    }
    public class GoldCustomer:Customer
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public double CustomerAmount { get; set; }

    }
    public class DiscountCustomer : Customer
    {
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public double CustomerAmount { get; set; }

    }
}
