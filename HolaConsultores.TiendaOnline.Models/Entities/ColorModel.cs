using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.TiendaOnline.Models.Entities
{
    public class ColorModel
    {
        public ColorModel() { }

        public ColorModel(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public IList<ProductColorModel> Products { get; set; } = new List<ProductColorModel>();

    }
}
