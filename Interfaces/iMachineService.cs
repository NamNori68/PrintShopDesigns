using PrintShopDesigns.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrintShopDesigns.Interfaces
{
    public interface iMachineService
    {
        Task<List<Machine>> ListAll();

        Task<List<Machine>> ListAllUsed(int Id);

        Task<Int32> Add(Int32 MachineID, Int32 DesignID);

        Task<Int32> Clear(Int32 DesignID);
    }
}
