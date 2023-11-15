using Microsoft.AspNetCore.Mvc.Filters;
using PrintShopDesigns.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintShopDesigns.Interfaces
{
    public interface iDesignService
    {
        Task<int> Create(Design design);
        Task<int> Clone(Design design);
        Task<int> Delete(int Id);
        Task<int> Update(Design design);
        Task<Design> GetById(int Id);
        Task<int> GetByKingId(string KingId);
        Task<int> GetNextId();
        Task<List<Design>> ListAll();
        Task<List<Design>> ListAllArchived();
        Task<List<Design>> ListAllActive();
    }
}
