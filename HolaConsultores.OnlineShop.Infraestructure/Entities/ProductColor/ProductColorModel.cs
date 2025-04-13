using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Infraestructure.Entities.Color;
using HolaConsultores.OnlineShop.Infraestructure.Entities.Product;

namespace HolaConsultores.OnlineShop.Infraestructure.Entities.ProductColor
{
    public class ProductColorModel
    {
        public ProductColorModel() { }

        public ProductColorModel(ProductModel product, ColorModel color) 
        {
            Product = product;
            Color = color;
        }

        public ProductColorModel(int productId, int colorId)
        {
            ProductId = productId;
            ColorId = colorId;
        }

        public ProductColorModel(int id, ProductModel product, ColorModel color)
        {
            Id = id;
            Product = product;
            Color = color;
        }

        public ProductColorModel(int id, int productId, int colorId)
        {
            Id = id;
            ProductId = productId;
            ColorId = colorId;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel? Product { get; set; }
        public int ColorId { get; set; }
        public ColorModel? Color { get; set; }

    }
}
