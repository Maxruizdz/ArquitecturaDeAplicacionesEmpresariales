using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Domain.Entity;
using System;

namespace Pacagroup.Ecommerce.Transversal.Mapper
{
    public class MappingsProfile : Profile
    {
        public MappingsProfile()
        {

            CreateMap<Customer, CustomersDto>()
             .ReverseMap();

            //CreateMap<Customer, CustomersDto>().ReverseMap()
            //    .ForMember(destination => destination.CustomerId, src => src.MapFrom(p => p.CustomerId))
            //    .ForMember(destination => destination.Fax, src => src.MapFrom(p => p.Fax))
            //    .ForMember(destination => destination.Address, src => src.MapFrom(p => p.Address))
            //    .ForMember(destination => destination.CompanyName, src => src.MapFrom(p => p.CompanyName))
            //    .ForMember(destination => destination.City, src => src.MapFrom(p => p.City))
            //    .ForMember(destination => destination.ContactName, src => src.MapFrom(p => p.ContactName))
            //    .ForMember(destination => destination.ContactTitle, src => src.MapFrom(p => p.ContactTitle))
            //    .ForMember(destination => destination.Country, src => src.MapFrom(p => p.Country))
            //    .ForMember(destination => destination.Phone, src => src.MapFrom(p => p.Phone))
            //    .ForMember(destination => destination.PostalCode, src => src.MapFrom(p => p.PostalCode))
            //    .ForMember(destination => destination.Region, src => src.MapFrom(p => p.Region));



        }
    }
}
