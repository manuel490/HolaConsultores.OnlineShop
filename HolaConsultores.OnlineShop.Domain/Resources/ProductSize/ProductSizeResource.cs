using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Resources.Product;

namespace HolaConsultores.OnlineShop.Domain.Resources.ProductSize
{
    public class ProductSizeResource
    {
        public ProductSizeResource() { }

        public ProductSizeResource(int id, int productId, int colorId)
        {
            Id = id;
            ProductId = productId;
            SizeId = colorId;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SizeId { get; set; }
    }
}
