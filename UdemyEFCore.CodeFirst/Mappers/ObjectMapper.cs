using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyEFCore.CodeFirst.DAL;
using UdemyEFCore.CodeFirst.DTOs;

namespace UdemyEFCore.CodeFirst.Mappers
{
    internal class ObjectMapper
    {
        private static readonly Lazy<IMapper> layz = new Lazy<IMapper>(() =>
         {

             var config = new MapperConfiguration(cfg =>
              {

                  cfg.AddProfile<CustomMapping>();
              });

             return config.CreateMapper();


         });

        public static IMapper Mapper => layz.Value;

    }

    internal class CustomMapping : Profile
    {

        public CustomMapping()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
        }
    }


}
