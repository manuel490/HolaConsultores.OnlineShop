using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.TiendaOnline.Domain.Resources.Color;
using HolaConsultores.TiendaOnline.Domain.Resources.Size;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;
using HolaConsultores.TiendaOnline.Mappers.ProductSize;

namespace HolaConsultores.TiendaOnline.Mappers.Size
{
    public static class SizeMapper
    {
        public static SizeModel ToModel(this SizeResource resource)
        {
            return new SizeModel(resource.Id, resource.Name);
        }

        public static IEnumerable<SizeModel> ToModel(this IEnumerable<SizeResource> resources)
        {
            foreach (SizeResource? item in resources)
            {
                if (item is not null)
                {
                    yield return item.ToModel();
                }
            }
        }

        public static SizeResource ToResource(this SizeModel model)
        {
            return new SizeResource(model.Id, model.Name, model.Products.GetProductResources());
        }

        public static IEnumerable<SizeResource> ToResource(this IEnumerable<SizeModel> models)
        {
            foreach (SizeModel? item in models)
            {
                if (item is not null)
                {
                    yield return item.ToResource();
                }
            }
        }
    }
}
