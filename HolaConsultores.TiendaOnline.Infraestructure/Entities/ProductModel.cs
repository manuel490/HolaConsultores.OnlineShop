using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.TiendaOnline.Infraestructure.Entities
{
    public class ProductModel
    {
        public ProductModel() { }
        public ProductModel(decimal price, string? description)
        {
            Price = price;
            Description = description;
        }

        public ProductModel(int id, decimal price, string? description)
        {
            Id = id;
            Price = price;
            Description = description;
        }

        public ProductModel(int id, IEnumerable<ProductSizeModel> sizes, IEnumerable<ProductColorModel> colors, decimal price, string? description)
        {
            Id = id;
            Sizes = sizes;
            Colors = colors;
            Price = price;
            Description = description;
        }

        public int Id { get; set; }
        public IEnumerable<ProductSizeModel> Sizes { get; set; } = new List<ProductSizeModel>();
        public IEnumerable<ProductColorModel> Colors { get; set; } = new List<ProductColorModel>();
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
