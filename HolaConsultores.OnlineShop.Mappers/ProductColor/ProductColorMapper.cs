using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Resources.Color;
using HolaConsultores.OnlineShop.Domain.Resources.Product;
using HolaConsultores.OnlineShop.Domain.Resources.ProductColor;
using HolaConsultores.OnlineShop.Domain.Resources.ProductSize;
using HolaConsultores.OnlineShop.Infraestructure.Entities;
using HolaConsultores.OnlineShop.Mappers.Color;
using HolaConsultores.OnlineShop.Mappers.Product;

namespace HolaConsultores.OnlineShop.Mappers.ProductColor
{
    public static class ProductColorMapper
    {
        public static ProductColorModel ToModel(this ProductColorResource resource)
        {
            return new ProductColorModel(resource.ProductId, resource.ColorId);
        }

        public static IEnumerable<ProductColorModel> ToModel(this IEnumerable<ProductColorResource> resources)
        {
            foreach (ProductColorResource? item in resources)
            {
                if (item is not null)
                {
                    yield return item.ToModel();
                }
            }
        }

        public static ProductColorResource ToResource(this ProductColorModel model)
        {
            return new ProductColorResource(model.ProductId, model.ColorId);
        }

        public static IEnumerable<ProductColorResource> ToResource(this IEnumerable<ProductColorModel> models)
        {
            foreach (ProductColorModel? item in models)
            {
                if (item is not null)
                {
                    yield return item.ToResource();
                }
            }
        }

        public static IEnumerable<ProductInputResource> GetProductResources(this IEnumerable<ProductColorModel> models)
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

        public static IEnumerable<ColorInputResource> GetColorResources(this IEnumerable<ProductColorModel> models)
        {
            var resources = new List<ColorInputResource>();

            foreach (var item in models)
            {
                if (item.Color != null)
                {
                    resources.Add(new ColorInputResource()
                    {
                        Id = item.Color.Id,
                        Name = item.Color.Name,
                    });
                }
            }
            return resources;
        }
    }
}
