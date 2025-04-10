using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.TiendaOnline.Infraestructure.Entities
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

        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel? Product { get; set; }
        public int SizeId { get; set; }
        public SizeModel? Size { get; set; }
    }
}
