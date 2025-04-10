using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolaConsultores.TiendaOnline.Domain.Resources.Size;
using HolaConsultores.TiendaOnline.Domain.Resources.User;
using HolaConsultores.TiendaOnline.Infraestructure.Entities;

namespace HolaConsultores.TiendaOnline.Mappers.User
{
    public static class UserMapper
    {
        public static UserModel ToModel(this UserResource resource)
        {
            return new UserModel()
            { 
                Id = resource.Id,
                Email = resource.Email,
                Password = resource.Password
            };
        }

        public static IEnumerable<UserModel> ToModel(this IEnumerable<UserResource> resources)
        {
            foreach (UserResource? item in resources)
            {
                if (item is not null)
                {
                    yield return item.ToModel();
                }
            }
        }

        public static UserResource ToResource(this UserModel model)
        {
            return new UserResource() 
            {
                Id = model.Id ,
                Email = model.Email ,
                Password = model.Password 
            };
        }

        public static IEnumerable<UserResource> ToResource(this IEnumerable<UserModel> models)
        {
            foreach (UserModel? item in models)
            {
                if (item is not null)
                {
                    yield return item.ToResource();
                }
            }
        }
    }
}
