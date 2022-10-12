using AutoMapper;
using PruebaTecnicaMarzan.Models;
using PruebaTecnicaMarzan.ViewModels;
using System.Linq;

namespace PruebaTecnicaMarzan.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(i => i.Customer,
                           y => y.MapFrom(z => z.Customer.Name))
                .ForMember(i => i.Cantidad,
                           y => y.MapFrom(z => z.OrderDetails.Sum(i => (i.Amount * i.Price))));
            CreateMap<OrderDetail, OrderDetailViewModel>()
                .ForMember(i => i.Product,
                           y => y.MapFrom(z => z.Product.Name));
        }
    }
}
