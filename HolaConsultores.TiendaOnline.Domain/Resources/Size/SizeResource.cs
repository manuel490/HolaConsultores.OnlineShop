using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.TiendaOnline.Domain.Resources.Product;

namespace HolaConsultores.TiendaOnline.Domain.Resources.Size
{
    public class SizeResource
    {
        public SizeResource() { }
        public SizeResource(string name)
        {
            Name = name;
        }
        public SizeResource(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public SizeResource(int id, string name, IEnumerable<ProductInputResource> products)
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
