using System;
using System.Collections.Generic;

namespace RestouracjaAPI.Models
{
    public partial class PizzaMenu
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
    }
}
