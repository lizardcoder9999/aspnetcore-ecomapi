using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.interfaces;
using Core.Models;
using Core.Models.OrderAggregate;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepository;


        public OrderService(IUnitOfWork unitOfWork,IBasketRepository basketRepo)
        {
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepo;
        }
        
        
        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            // get basket from the repo
            var basket = await _basketRepository.GetBasketAsync(basketId);
            // get items from the product repo
            var items = new List<OrderItem>();
            foreach (var item in basket.Items)
            {
                var productItem = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }
            //get delivery method from the repo
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);
            //Calculate subtotal
            var subtotal = items.Sum(item => item.Price * item.Quantity);
            //create order
            var order = new Order(buyerEmail,shippingAddress,deliveryMethod,items,subtotal);
            _unitOfWork.Repository<Order>().Add(order);
            
            //save to db
            var result = await _unitOfWork.Complete();

            if (result <= 0) return null;
            
            //delete basket
            await _basketRepository.DeleteBasketAsync(basketId);

            //return order
            return order;
        }

        public Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new System.NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
