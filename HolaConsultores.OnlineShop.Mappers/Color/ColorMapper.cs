using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Resources.Color;
using HolaConsultores.OnlineShop.Domain.Resources.Product;
using HolaConsultores.OnlineShop.Infraestructure.Entities.Color;
using HolaConsultores.OnlineShop.Mappers.Product;
using HolaConsultores.OnlineShop.Mappers.ProductColor;

namespace HolaConsultores.OnlineShop.Mappers.Color
{
    public static class ColorMapper
    {
        public static ColorModel ToModel(this ColorResource resource)
        {
            return new ColorModel(resource.Id, resource.Name);
        }

        public static IEnumerable<ColorModel> ToModel(this IEnumerable<ColorResource> resources)
        {
            foreach (ColorResource? item in resources)
            {
                if (item is not null)
                {
                    yield return item.ToModel();
                }
            }
        }

        public static ColorResource ToResource(this ColorModel model)
        {
            return new ColorResource(model.Id, model.Name, model.Products.GetProductResources());
        }

        public static IEnumerable<ColorResource> ToResource(this IEnumerable<ColorModel> models)
        {
            foreach (ColorModel? item in models)
            {
                if (item is not null)
                {
                    yield return item.ToResource();
                }
            }
        }
    }
}
