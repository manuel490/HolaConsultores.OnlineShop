using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.OnlineShop.Domain.Resources.Product;
using HolaConsultores.OnlineShop.Domain.Resources.Size;
using HolaConsultores.OnlineShop.Infraestructure.Entities;
using HolaConsultores.OnlineShop.Mappers.ProductColor;
using HolaConsultores.OnlineShop.Mappers.ProductSize;
using HolaConsultores.OnlineShop.Mappers.Size;

namespace HolaConsultores.OnlineShop.Mappers.Product
{
    public static class ProductMapper
    {
        public static ProductModel ToModel(this ProductResource resource)
        {
            return new ProductModel(resource.Id, resource.Price, resource.Description);
        }

        public static IEnumerable<ProductModel> ToModel(this IEnumerable<ProductResource> resources)
        {
            foreach (ProductResource? item in resources)
            {
                if (item is not null)
                {
                    yield return item.ToModel();
                }
            }
        }

        public static ProductResource ToResource(this ProductModel model)
        {
            return new ProductResource(model.Id,
                                       model.Sizes.GetSizeResources(),
                                       model.Colors.GetColorResources(),
                                       model.Price,
                                       model.Description);
        }

        public static IEnumerable<ProductResource> ToResource(this IEnumerable<ProductModel> models)
        {
            foreach (ProductModel? item in models)
            {
                if (item is not null)
                {
                    yield return item.ToResource();
                }
            }
        }

    }
}
