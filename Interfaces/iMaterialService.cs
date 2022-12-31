using PrintShopDesigns.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintShopDesigns.Interfaces
{
    public interface IMaterialService
    {
        Task<int> Create(Material material);
        Task<int> Delete(int Id);
        Task<int> Update(Material material);
        Task<Material> GetById(int Id);
        Task<List<Material>> ListAll();
    }
}
