using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.TiendaOnline.Domain.Resources.Color;
using HolaConsultores.TiendaOnline.Domain.Resources.Product;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;
using HolaConsultores.TiendaOnline.Mappers.Product;
using HolaConsultores.TiendaOnline.Mappers.ProductColor;

namespace HolaConsultores.TiendaOnline.Mappers.Color
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
