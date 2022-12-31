using PrintShopDesigns.Interfaces;
using PrintShopDesigns.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PrintShopDesigns.Data
{
    public class MaterialService : IMaterialService
    {
        private readonly IDapperService _dapperService;

        public MaterialService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }
        
        public Task<int> Create(Material material)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("Name", material.Name, DbType.String);
            dbPara.Add("Type", material.Type, DbType.String);
            dbPara.Add("CubicFootWeight", material.CubicFootWeight, DbType.Double);
            dbPara.Add("Notes1", material.Notes1, DbType.String);
            dbPara.Add("Notes2", material.Notes2, DbType.String);

            var MaterialId = Task.FromResult(_dapperService.Insert<int>("dbo.usp_Material_Add", dbPara, commandType: CommandType.StoredProcedure));

            return MaterialId;
        }

        public Task<Material> GetById(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("MaterialID", id, DbType.Int16);

            var Material = Task.FromResult(_dapperService.Get<Material>("dbo.usp_Material_GetByID", dbPara, commandType: CommandType.StoredProcedure));

            return Material;
        }

        public Task<int> Delete(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("MaterialID", id, DbType.Int16);

            var deleteMaterial = Task.FromResult(_dapperService.Execute("dbo.usp_Material_DeleteByID", dbPara, commandType: CommandType.StoredProcedure));

            return deleteMaterial;
        }

        public Task<List<Material>> ListAll()
        {
            var materials = Task.FromResult(_dapperService.GetAll<Material>("dbo.usp_Material_GetAll", null, commandType: CommandType.StoredProcedure));

            return materials;
        }

        public Task<int> Update(Material material)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("MaterialID", material.MaterialID, DbType.Int16);
            dbPara.Add("Name", material.Name, DbType.String);
            dbPara.Add("Type", material.Type, DbType.String);
            dbPara.Add("CubicFootWeight", material.CubicFootWeight, DbType.Double);
            dbPara.Add("Notes1", material.Notes1, DbType.String);
            dbPara.Add("Notes2", material.Notes2, DbType.String);

            var updateMaterial = Task.FromResult(_dapperService.Update<int>("dbo.usp_Material_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateMaterial;
        }
    }
}
