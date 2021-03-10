using System.Threading.Tasks;
using Core.Models;
using Core.Models.OrderAggregate;
using Microsoft.VisualBasic.CompilerServices;

namespace Core.interfaces
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
        Task<Order> UpdateOrderPaymentSucceeded(string paymentIntentId);

        Task<Order> UpdateOrderPaymentFailed(string paymentIntentId);

    }
}
