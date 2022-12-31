using PrintShopDesigns.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintShopDesigns.Interfaces
{
    public interface IMaterialReceivedService
    {
        Task<int> Create(MaterialReceived materialReceived);
        Task<int> Delete(int Id);
        Task<int> Update(MaterialReceived materialReceived);
        Task<MaterialReceived> GetById(int Id);
        Task<List<MaterialReceived>> ListAll();
    }
}
