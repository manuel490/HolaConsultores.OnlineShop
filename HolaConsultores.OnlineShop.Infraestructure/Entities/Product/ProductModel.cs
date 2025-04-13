using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Infraestructure.Entities.ProductColor;
using HolaConsultores.OnlineShop.Infraestructure.Entities.ProductSize;

namespace HolaConsultores.OnlineShop.Infraestructure.Entities.Product
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
