using BusinessLogic.IRepo;
using BusinessLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Repo
{
    public class ProductRepo : IProductRepo
    {
        private readonly AppDb _db;
        public ProductRepo(AppDb db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductData>> GetProductsAsync()
        {
            var res = await (from s in _db.ProductTable select s).ToListAsync();
            return res;
        }

        public async Task AddProductsAsync(ProductData data)
        {
            _db.ProductTable.Add(data);
            await _db.SaveChangesAsync();
        }

        public async Task<ProductData> FindProductAsync(int Id)
        {
            var data = await _db.ProductTable.FindAsync(Id);
            return data;
        }

        public async Task UpdateProductAsync(ProductData data)
        {
            _db.ProductTable.Update(data);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int Id)
        {
            var product = await _db.ProductTable.FindAsync(Id);
            _db.ProductTable.Remove(product);
            await _db.SaveChangesAsync();
        }

    }
}
