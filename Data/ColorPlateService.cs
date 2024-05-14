using PrintShopDesigns.Interfaces;
using PrintShopDesigns.Entities;
using System.Data;
using Dapper;

namespace PrintShopDesigns.Data
{
    public class ColorPlateService : iColorPlateService
    {
        private readonly IDapperService _dapperService;

        public ColorPlateService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }

        public Task<int> Add(ColorPlate _colorPlate, int _designID)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("DesignID", _designID, DbType.String);
            dbPara.Add("Color", _colorPlate.Color, DbType.String);
            dbPara.Add("Spec", _colorPlate.Spec, DbType.String);
            dbPara.Add("Common", _colorPlate.Common, DbType.String);


            var ColorPlateID = Task.FromResult(_dapperService.Insert<int>("dbo.usp_ColorPlates_Add", dbPara, commandType: CommandType.StoredProcedure));

            return ColorPlateID;
        }

        public Task<List<ColorPlate>> ListAllbyDesignID(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("DesignID", id, DbType.Int16);

            var _colorPlate = Task.FromResult(_dapperService.GetAll<ColorPlate>("dbo.usp_ColorPlates_GetAllbyDesignID", dbPara, commandType: CommandType.StoredProcedure));

            return _colorPlate;
        }

        public Task<int> Delete(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("ColorPlateID", id, DbType.Int16);

            var deleteColorPlate = Task.FromResult(_dapperService.Execute("dbo.usp_ColorPlates_DeleteByID", dbPara, commandType: CommandType.StoredProcedure));

            return deleteColorPlate;
        }

        public Task<int> Update(ColorPlate _colorPlate)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("ColorPlateID", _colorPlate.ColorPlateID, DbType.Int16);
            dbPara.Add("Color", _colorPlate.Color, DbType.String);
            dbPara.Add("Spec", _colorPlate.Spec, DbType.String);
            dbPara.Add("Common", _colorPlate.Common, DbType.Boolean);

            var updateColorPlate = Task.FromResult(_dapperService.Update<int>("dbo.usp_ColorPlates_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateColorPlate;
        }
    }
}
