using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.IRepo
{
    public interface IProductRepo
    {
        public Task<IEnumerable<ProductData>> GetProductsAsync();
        public Task AddProductsAsync(ProductData data);
        public Task<ProductData> FindProductAsync(int Id);
        public Task UpdateProductAsync(ProductData data);
        public Task DeleteProductAsync(int Id);
    }
}
