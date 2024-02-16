using AutoMapper;
using ManufuctredCompanyPortofolio.DAL.Entities;
using ManufuctredCompanyPortofolio.PL.Models;
using Microsoft.AspNetCore.Identity;

namespace ManufuctredCompanyPortofolio.PL.Mapers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, RegisterViewModel>().ReverseMap();
        }
    }
}
