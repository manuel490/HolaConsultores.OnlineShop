using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.TiendaOnline.Models.Entities
{
    public class ProductModel
    {
        public ProductModel() { }
        public ProductModel(IList<ProductSizeModel> sizes, IList<ProductColorModel> colors, decimal price, string? description)
        {
            Sizes = sizes;
            Colors = colors;
            Price = price;
            Description = description;
        }

        public int Id { get; set; }
        public IList<ProductSizeModel> Sizes { get; set; } = new List<ProductSizeModel>();
        public IList<ProductColorModel> Colors { get; set; } = new List<ProductColorModel>();
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    }
}
