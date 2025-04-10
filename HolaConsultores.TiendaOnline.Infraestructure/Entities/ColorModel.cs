using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.TiendaOnline.Infraestructure.Entities
{
    public class ColorModel
    {
        public ColorModel() { }

        public ColorModel(string name)
        {
            Name = name;
        }

        public ColorModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public ColorModel(int id, string name, IEnumerable<ProductColorModel> products)
        {
            Id = id;
            Name = name;
            Products = products;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<ProductColorModel> Products { get; set; } = new List<ProductColorModel>();

    }
}
