using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Resources.Color;
using HolaConsultores.OnlineShop.Domain.Resources.Size;

namespace HolaConsultores.OnlineShop.Domain.Resources.Product
{
    public class ProductResource
    {
        public ProductResource() { }

        public ProductResource(decimal price, string? description)
        {
            Price = price;
            Description = description;
        }

        public ProductResource(int id, decimal price, string? description)
        {
            Id = id;
            Price = price;
            Description = description;
        }

        public ProductResource(
            int id,
            IEnumerable<SizeInputResource> sizes, 
            IEnumerable<ColorInputResource> colors, 
            decimal price, 
            string? description
            )
        {
            Id = id;
            Sizes = sizes;
            Colors = colors;
            Price = price;
            Description = description;
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public IEnumerable<SizeInputResource> Sizes { get; set; } = new List<SizeInputResource>();
        public IEnumerable<ColorInputResource> Colors { get; set; } = new List<ColorInputResource>();
        
    }
}
