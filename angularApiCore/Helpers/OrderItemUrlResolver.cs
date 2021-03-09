using angularApiCore.Dtos;
using AutoMapper;
using Core.Models.OrderAggregate;
using Microsoft.Extensions.Configuration;

namespace angularApiCore.Helpers
{
    public class OrderItemUrlResolver : IValueResolver<OrderItem, OrderItemDto,string>
    {

        private readonly IConfiguration _configuration;
        
        public OrderItemUrlResolver(IConfiguration config)
        {
            _configuration = config;
        }
        
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ItemOrdered.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.ItemOrdered.PictureUrl;
            }

            return null;
        }
    }
}
