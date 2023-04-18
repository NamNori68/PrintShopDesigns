using PrintShopDesigns.Interfaces;
using PrintShopDesigns.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PrintShopDesigns.Pages;

namespace PrintShopDesigns.Data
{
    public class DesignService : iDesignService
    {
        private readonly IDapperService _dapperService;


        public DesignService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }

        public Task<int> Create(Design _design)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("DesignID", _design.DesignID, DbType.Int16);
            dbPara.Add("Item", _design.Item, DbType.String);
            dbPara.Add("Color", _design.Color, DbType.String);
            dbPara.Add("Hold", _design.Hold, DbType.Binary);
            dbPara.Add("Notes", _design.Notes, DbType.String);

            var _designID = Task.FromResult(_dapperService.Insert<int>("dbo.usp_Design_Add", dbPara, commandType: CommandType.StoredProcedure));

            return _designID;
        }

        public Task<Design> GetById(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("DesignID", id, DbType.Int16);

            var _design = Task.FromResult(_dapperService.Get<Design>("dbo.usp_Design_GetByID", dbPara, commandType: CommandType.StoredProcedure));

            return _design;
        }

        public Task<string> GetNextId()
        {
            var _nextID = Task.FromResult(_dapperService.GetID("dbo.usp_Designs_GetNextID", null, commandType: CommandType.StoredProcedure));

            return _nextID;
        }

        public Task<int> Delete(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("DesignID", id, DbType.Int16);

            var deleteDesign = Task.FromResult(_dapperService.Execute("dbo.usp_Design_DeleteByID", dbPara, commandType: CommandType.StoredProcedure));

            return deleteDesign;
        }

        public Task<List<Design>> ListAll()
        {
            var _design = Task.FromResult(_dapperService.GetAll<Design>("dbo.usp_Design_GetAll", null, commandType: CommandType.StoredProcedure));

            return _design;
        }

        public Task<int> Update(Design _design)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("DesignID", _design.DesignID, DbType.Int16);
            dbPara.Add("Item", _design.Item, DbType.String);
            dbPara.Add("Color", _design.Color, DbType.String);
            dbPara.Add("Hold", _design.Hold, DbType.Binary);
            dbPara.Add("Notes", _design.Notes, DbType.String);

            var updateDesign = Task.FromResult(_dapperService.Update<int>("dbo.usp_Product_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateDesign;
        }
    }
}
