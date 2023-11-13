using AutoMapper;
using OrderApp.Entity.Models;
using OrderApp.Shared;

namespace OrderApp.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderForCreateViewModel, Order>()
                .ForMember(c => c.Number, opt => opt.MapFrom(c => c.NumberOrder))
                .ForMember(c => c.Date, opt => opt.MapFrom(c => c.Date))
                .ForMember(c => c.ProviderId, opt => opt.MapFrom(c => c.ProviderId));
            CreateMap<OrderForCreateViewModel, OrderItem>()
                .ForMember(c => c.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(c => c.Quantity, opt => opt.MapFrom(c => c.Quantity))
                .ForMember(c => c.Unit, opt => opt.MapFrom(c => c.Unit));
            CreateMap<Order, OrderViewModel>()
                .ForMember(c=>c.ProviderName, opt=>opt.MapFrom(c=>c.Provider.Name));

        }
    }
}
