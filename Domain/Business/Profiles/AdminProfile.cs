using AutoMapper;
using Domain.Models;
using IASHandyMan.CrossCutting.ApplicationModel;

namespace Domain.Business.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Menu, MenuAM>().ReverseMap();
            CreateMap<Person, PersonAM>().ReverseMap();
            CreateMap<States, StatesAM>().ReverseMap();
            CreateMap<RolMenu, RolMenuAM>().ReverseMap();
            CreateMap<Services, ServicesAM>().ReverseMap();
            CreateMap<PersonServices, PersonServicesAM>().ReverseMap();
        }
    }
}
