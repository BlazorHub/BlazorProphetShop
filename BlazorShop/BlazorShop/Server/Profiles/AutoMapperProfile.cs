using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorShop.Shared.DTOs.Order;
using BlazorShop.Shared.DTOs.Product;
using BlazorShop.Shared.DTOs.User;
using BlazorShop.Shared.DTOs.Category;
using BlazorShop.Shared.ViewModels;
using BlazorShop.Shared.Models;
using BlazorShop.Server.Business;
using AutoMapper;


namespace BlazorShop.Server.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductViewModel>().ForMember(dst => dst.ImageName,
                                                             opt => opt.MapFrom(src => $"https://blazorshop.blob.core.windows.net/images/{src.ImageName}"))
                                                  .ForMember(dst => dst.CategoryName,
                                                             opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<CreateProductDTO, Product>().ForMember(dst => dst.ImageName,
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
            CreateMap<CreateUserAddressDTO, Address>();
            CreateMap<CreateUserDTO, User>().ForMember(dst => dst.Enabled,
                                                       opt => opt.MapFrom(src => true))
                                            .ForMember(dst => dst.Discriminator,
                                                       opt => opt.MapFrom(src => "Customer"))
                                            .ForMember(dst => dst.CreatedAt,
                                                       opt => opt.MapFrom(src => DateTime.Now))
                                            .ForMember(dst => dst.UpdatedAt,
                                                       opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<Address, CreateUserAddressDTO>();
            CreateMap<User, UpdateUserDTO>().ForMember(dst => dst.Address,
                                                       opt => opt.MapFrom(src => src.Address ?? new Address()));
            CreateMap<Category, GetCategoryDTO>();
            CreateMap<User, GetUserDTO>();
        }
    }
}
