using System;
using System.Collections.Generic;
using System.Text;

namespace Такси.Models
{
    public class Adresses
    {
        public int Id { get; set; }
        public string Adress { get; set; }
        public int OrderId { get; set; }
    }
}
