using System;
using AutoMapper;
using Provera.Pamera.API.ViewModels;
using Provera.Pamera.Model.Concrete;

namespace Provera.Pamera.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductVM>().ReverseMap();
        }
    }
}
