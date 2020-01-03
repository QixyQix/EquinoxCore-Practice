using AutoMapper;
using EquinoxCore.Application.ViewModels;
using EquinoxCore.Domain.Models;

namespace EquinoxCore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() {
            CreateMap<Customer, CustomerViewModel>();
        }
    }
}
