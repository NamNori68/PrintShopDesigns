using PrintShopDesigns.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintShopDesigns.Interfaces
{
    public interface IProductService
    {
        Task<int> Create(Product product);
        Task<int> Delete(int Id);
        Task<int> Update(Product product);
        Task<Product> GetById(int Id);
        Task<String> GetTypeByName(string Name);
        Task<List<Product>> ListAll();
    }
}