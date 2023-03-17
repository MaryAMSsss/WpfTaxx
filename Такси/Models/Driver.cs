using System;
using System.Collections.Generic;
using System.Text;

namespace Такси.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int LevelId { get; set; }
        public int CarId { get; set; }
    }
}
