using System.Threading.Tasks;
using Core.Models;

namespace Core.interfaces
{
    public interface IPaymentService
    {
        Task<CustomerBasket> CreateOrUpdatePaymentIntent(string basketId);
        
    }
}
