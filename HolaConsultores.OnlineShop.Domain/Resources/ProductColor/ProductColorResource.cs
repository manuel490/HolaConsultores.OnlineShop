using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaConsultores.OnlineShop.Domain.Resources.ProductColor
{
    public class ProductColorResource
    {
        public ProductColorResource() { }

        public ProductColorResource(int id, int productId, int colorId)
        {
            Id = id;
            ProductId = productId;
            ColorId = colorId;
        }

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
    }
}
