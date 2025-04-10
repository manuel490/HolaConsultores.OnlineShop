using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.TiendaOnline.Domain.Resources.Color;
using HolaConsultores.TiendaOnline.Domain.Resources.Product;
using HolaConsultores.TiendaOnline.Domain.Resources.ProductSize;
using HolaConsultores.TiendaOnline.Domain.Resources.Size;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;
using HolaConsultores.TiendaOnline.Mappers.Color;
using HolaConsultores.TiendaOnline.Mappers.Product;
using HolaConsultores.TiendaOnline.Mappers.Size;

namespace HolaConsultores.TiendaOnline.Mappers.ProductSize
{
    public static class ProductSizeMapper
    {
        public static ProductSizeModel ToModel(this ProductSizeResource resource)
        {
            return new ProductSizeModel(resource.ProductId, resource.SizeId);
        }

        public static IEnumerable<ProductSizeModel> ToModel(this IEnumerable<ProductSizeResource> resources)
        {
            foreach (ProductSizeResource? item in resources)
            {
                if (item is not null)
                {
                    yield return item.ToModel();
                }
            }
        }

        public static ProductSizeResource ToResource(this ProductSizeModel model)
        {
            return new ProductSizeResource(model.ProductId, model.SizeId);
        }

        public static IEnumerable<ProductSizeResource> ToResource(this IEnumerable<ProductSizeModel> models)
        {
            foreach (ProductSizeModel? item in models)
            {
                if (item is not null)
                {
                    yield return item.ToResource();
                }
            }
        }

        public static IEnumerable<ProductInputResource> GetProductResources(this IEnumerable<ProductSizeModel> models)
        {
            var resources = new List<ProductInputResource>();

            foreach (var item in models)
            {
                if (item.Product != null)
                {
                    resources.Add(new ProductInputResource()
                    {
                        Id = item.Product.Id,
                        Price = item.Product.Price,
                        Description = item.Product.Description,
                    });
                }
            }
            return resources;
        }

        public static IEnumerable<SizeInputResource> GetSizeResources(this IEnumerable<ProductSizeModel> models)
        {
            var resources = new List<SizeInputResource>();

            foreach (var item in models)
            {
                if (item.Size != null)
                {
                    resources.Add(new SizeInputResource()
                    {
                        Id = item.Size.Id,
                        Name = item.Size.Name,
                    });
                }
            }
            return resources;
        }
    }
}
