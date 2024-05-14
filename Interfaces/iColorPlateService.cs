using PrintShopDesigns.Entities;

namespace PrintShopDesigns.Interfaces
{
    public interface iColorPlateService
    {
        Task<List<ColorPlate>> ListAllbyDesignID(int Id);

        Task<int> Delete(int Id);

        Task<int> Add(ColorPlate colorPlate, int _designID);

        Task<int> Update(ColorPlate colorPlate);
    }
}
