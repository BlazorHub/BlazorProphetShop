using AutoMapper;
using BlazorShop.Shared.DTOs;
using BlazorShop.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Server.Business;

namespace BlazorShop.Server.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductViewModel>().ForMember(dst => dst.ImageName,
                                                             opt => opt.MapFrom(src => $"https://blazorshop.blob.core.windows.net/images/{src.ImageName}"));
            CreateMap<AddProductDTO, Product>().ForMember(dst => dst.ImageName,
                                                          opt => opt.MapFrom(src => src.Name.ToLower().Replace(' ', '_') + ".png"))
                                               .ForMember(dst => dst.Enabled,
                                                          opt => opt.MapFrom(src => true))
                                               .ForMember(dst => dst.CreatedAt,
                                                          opt => opt.MapFrom(src => DateTime.Now))
                                               .ForMember(dst => dst.UpdatedAt,
                                                          opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<OrderProduct, OrderProductViewModel>().ForMember(dst => dst.Quantity,
                                                                       opt => opt.MapFrom(src => src.Quantity))
                                                            .ForMember(dst => dst.ImageName,
                                                                       opt => opt.MapFrom(src => $"https://blazorshop.blob.core.windows.net/images/{src.Product.ImageName}"))
                                                            .ForMember(dst => dst.ProductName,
                                                                       opt => opt.MapFrom(src => src.Product.Name));
            CreateMap<Order, CustomerOrderViewModel>().ForMember(dst => dst.Total,
                                                         opt => opt.MapFrom(src => Orders.CalculateGrandTotal(src)));
            CreateMap<Order, ManagerOrderItemViewModel>().ForMember(dst => dst.Total,
                                                               opt => opt.MapFrom(src => Orders.CalculateGrandTotal(src)))
                                                         .ForMember(dst => dst.CustomerName,
                                                               opt => opt.MapFrom(src => src.Customer.Name));
            CreateMap<Order, ManagerOrderViewModel>().ForMember(dst => dst.ShippingValue,
                                                                opt => opt.MapFrom(src => Orders.CalculateShippingValue(src)))
                                                     .ForMember(dst => dst.ProductsValue,
                                                                opt => opt.MapFrom(src => Orders.CalculateProductsValue(src)))
                                                     .ForMember(dst => dst.DiscountValue,
                                                                opt => opt.MapFrom(src => Orders.CalculateDiscountValue(src)))
                                                     .ForMember(dst => dst.Total,
                                                                opt => opt.MapFrom(src => Orders.CalculateGrandTotal(src)))
                                                     .ForMember(dst => dst.CustomerName,
                                                               opt => opt.MapFrom(src => src.Customer.Name));
        }
    }
}
