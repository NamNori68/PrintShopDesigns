using PrintShopDesigns.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintShopDesigns.Interfaces
{
    public interface ICustomerService
    {
        Task<int> Create(Customer customer);
        Task<int> Delete(int Id);
        Task<int> Update(Customer customer);
        Task<Customer> GetById(int Id);
        Task<List<Customer>> ListAll();
    }
}
