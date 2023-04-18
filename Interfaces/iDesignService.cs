using Microsoft.AspNetCore.Mvc.Filters;
using PrintShopDesigns.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintShopDesigns.Interfaces
{
    public interface iDesignService
    {
        Task<int> Create(Design design);
        Task<int> Delete(int Id);
        Task<int> Update(Design design);
        Task<Design> GetById(int Id);
        Task<string> GetNextId();
        Task<List<Design>> ListAll();
    }
}
