using System;
using System.Linq.Expressions;
using Core.Models.OrderAggregate;

namespace Core.Specifications
{
    public class OrdersWIthItemsAndOrderingSpecification : BaseSpecification<Order>
    {
        public OrdersWIthItemsAndOrderingSpecification(string email) : base(order => order.BuyerEmail == email )
        {
            AddInclude(order => order.OrderItems);
            AddInclude(order => order.DeliveryMethod);
            AddOrderByDescending(order => order.OrderDate);
        }

        public OrdersWIthItemsAndOrderingSpecification(int id, string email) : 
            base(order => order.Id == id && order.BuyerEmail == email)
        {
            AddInclude(order => order.OrderItems);
            AddInclude(order => order.DeliveryMethod);
        }
    }
}
