using System;
using System.Collections.Generic;
using System.Text;

namespace _1234.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public string Отчество { get; set; }
        public DateTime ДатаРождения { get; set; }
        public string Телефон { get; set; }
        public int IdДолжности { get; set; }
        public string Город { get; set; }
        public string Улица { get; set; }
        public string Дом { get; set; }
        public DateTime ДатаНайма { get; set; }
        public DateTime ДатаУвольнения { get; set; }
    }
}
