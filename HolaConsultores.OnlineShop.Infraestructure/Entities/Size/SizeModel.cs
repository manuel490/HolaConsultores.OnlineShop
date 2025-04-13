using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Infraestructure.Entities.ProductSize;

namespace HolaConsultores.OnlineShop.Infraestructure.Entities.Size
{
    public class SizeModel
    {
        public SizeModel() { }
        public SizeModel(string name)
        {
            Name = name;
        }
        public SizeModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public SizeModel(int id, string name, IEnumerable<ProductSizeModel> products)
        {
            Id = id;
            Name = name;
            Products = products;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<ProductSizeModel> Products { get; set; } = new List<ProductSizeModel>();

    }
}
