using PrintShopDesigns.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintShopDesigns.Interfaces
{
    public interface iColorService
    {
        Task<List<Color>> ListAll();
    }
}
