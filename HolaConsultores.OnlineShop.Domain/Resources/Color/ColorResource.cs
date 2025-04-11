using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Resources.Product;

namespace HolaConsultores.OnlineShop.Domain.Resources.Color
{
    public class ColorResource
    {
        public ColorResource() { }

        public ColorResource(string name)
        {
            Name = name;
        }

        public ColorResource(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ColorResource(int id, string name, IEnumerable<ProductInputResource> products)
        {
            Id = id;
            Name = name;
            Products = products;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductInputResource> Products { get; set; }
    }
}
