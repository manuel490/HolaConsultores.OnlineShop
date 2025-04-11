using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.OnlineShop.Resources.DTOs
{
    public class ProductResource
    {
        public int Id { get; set; }
        public List<SizeResource> Sizes { get; set; } = new List<SizeResource>();
        public List<ColorResource> Colors { get; set; } = new List<ColorResource>();
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
