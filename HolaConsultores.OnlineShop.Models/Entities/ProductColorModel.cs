using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.OnlineShop.Models.Entities
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

        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel? Product { get; set; }
        public int ColorId { get; set; }
        public ColorModel? Color { get; set; }

    }
}
