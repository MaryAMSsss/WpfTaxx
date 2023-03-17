using System;
using System.Collections.Generic;
using System.Text;

namespace Такси.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int Status { get; set; }
        public int ClientId { get; set; }
        
    }
}
