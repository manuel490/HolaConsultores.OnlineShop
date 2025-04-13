using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Infraestructure.Entities.Product;
using HolaConsultores.OnlineShop.Infraestructure.Entities.Size;

namespace HolaConsultores.OnlineShop.Infraestructure.Entities.ProductSize
{
    public class ProductSizeModel
    {
        public ProductSizeModel() { }

        public ProductSizeModel(ProductModel product, SizeModel color)
        {
            Product = product;
            Size = color;
        }

        public ProductSizeModel(int productId, int colorId)
        {
            ProductId = productId;
            SizeId = colorId;
        }

        public ProductSizeModel(int id, ProductModel product, SizeModel color)
        {
            Id = id;
            Product = product;
            Size = color;
        }

        public ProductSizeModel(int id, int productId, int colorId)
        {
            Id = id;
            ProductId = productId;
            SizeId = colorId;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel? Product { get; set; }
        public int SizeId { get; set; }
        public SizeModel? Size { get; set; }
    }
}
