using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Resources.Color;
using HolaConsultores.OnlineShop.Domain.Resources.Size;

namespace HolaConsultores.OnlineShop.Domain.Resources.Product
{
    public class ProductInputResource
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
