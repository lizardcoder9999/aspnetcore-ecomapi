using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.interfaces
{
   public interface IProductRepository
   {
       Task<Product> GetProductByIdAsync(int id);
       Task<IReadOnlyList<Product>> GetProductsAsync();
   }
}
