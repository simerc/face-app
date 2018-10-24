using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FaceImage.Api.Models.Registration;
using FaceImage.Entities;

namespace FaceImage.Api.Infrastructure.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterViewModel, AppUser>();
        }
    }
}
