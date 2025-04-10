using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.TiendaOnline.Models.Entities
{
    public class SizeModel
    {
        public SizeModel() { }

        public SizeModel(string? name, IList<ProductSizeModel> products)
        {
            Name = name;
            Products = products;
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public IList<ProductSizeModel> Products { get; set; } = new List<ProductSizeModel>();

    }
}
