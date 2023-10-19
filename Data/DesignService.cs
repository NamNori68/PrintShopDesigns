using PrintShopDesigns.Interfaces;
using PrintShopDesigns.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PrintShopDesigns.Pages;
using DevExpress.XtraRichEdit.Import.OpenXml;
using DevExpress.RichEdit.Export;

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
            _design.Created = DateTime.Today;

            var dbPara = new DynamicParameters();

            dbPara.Add("KingDesignID", _design.KingDesignID, DbType.String);
            dbPara.Add("Item", _design.Item, DbType.String);
            dbPara.Add("Color", _design.Color, DbType.String);
            dbPara.Add("Hold", _design.Hold, DbType.Boolean);
            dbPara.Add("Notes", _design.Notes, DbType.String);
            dbPara.Add("Customer", _design.Customer, DbType.String);
            dbPara.Add("LabelPosition", _design.LabelPosition, DbType.Int32);
            dbPara.Add("Description", _design.Description, DbType.String);
            dbPara.Add("Weight", _design.Weight, DbType.String);
            dbPara.Add("UPC", _design.UPC, DbType.String);
            dbPara.Add("CustomerItemCode", _design.CustomerItemCode, DbType.String);
            dbPara.Add("Created", _design.Created, DbType.Date);
            dbPara.Add("Updated", _design.Updated, DbType.Date);
            dbPara.Add("Archived", _design.Archived, DbType.Boolean);

            var _designID = Task.FromResult(_dapperService.Insert<int>("dbo.usp_Design_Add", dbPara, commandType: CommandType.StoredProcedure));

            return _designID;
        }

        public Task<int> Clone(Design _design)
        {
            // save the original and flag as Archived
            var dbPara = new DynamicParameters();

            _design.Archived = true;
            _design.Updated = DateTime.Today;

            dbPara.Add("DesignID", _design.DesignID, DbType.Int32);
            dbPara.Add("KingDesignID", _design.KingDesignID, DbType.String);
            dbPara.Add("Item", _design.Item, DbType.String);
            dbPara.Add("Color", _design.Color, DbType.String);
            dbPara.Add("Hold", _design.Hold, DbType.Boolean);
            dbPara.Add("Notes", _design.Notes, DbType.String);
            dbPara.Add("Customer", _design.Customer, DbType.String);
            dbPara.Add("LabelPosition", _design.LabelPosition, DbType.Int32);
            dbPara.Add("Description", _design.Description, DbType.String);
            dbPara.Add("Weight", _design.Weight, DbType.String);
            dbPara.Add("UPC", _design.UPC, DbType.String);
            dbPara.Add("CustomerItemCode", _design.CustomerItemCode, DbType.String);
            dbPara.Add("Created", _design.Created, DbType.Date);
            dbPara.Add("Updated", _design.Updated, DbType.Date);
            dbPara.Add("Archived", _design.Archived, DbType.Boolean);

            var updateOriginal = Task.FromResult(_dapperService.Update<int>("dbo.usp_Design_Update", dbPara, commandType: CommandType.StoredProcedure));

            // now create the clone and save it as a new entry
            var dbPara2 = new DynamicParameters();

            // get the current version of the ID, which is the last character, increment it by one letter, then re-concantenate
            char baseID = _design.KingDesignID.Substring(_design.KingDesignID.Length - 1)[0];
            baseID++;

            _design.KingDesignID = string.Concat(_design.KingDesignID.Substring(0, _design.KingDesignID.Length - 1), baseID.ToString());
            _design.Archived = false;
            _design.Created = DateTime.Today;

            dbPara2.Add("KingDesignID", _design.KingDesignID, DbType.String);
            dbPara2.Add("Item", _design.Item, DbType.String);
            dbPara2.Add("Color", _design.Color, DbType.String);
            dbPara2.Add("Hold", _design.Hold, DbType.Boolean);
            dbPara2.Add("Notes", _design.Notes, DbType.String);
            dbPara2.Add("Customer", _design.Customer, DbType.String);
            dbPara2.Add("LabelPosition", _design.LabelPosition, DbType.Int32);
            dbPara2.Add("Description", _design.Description, DbType.String);
            dbPara2.Add("Weight", _design.Weight, DbType.String);
            dbPara2.Add("UPC", _design.UPC, DbType.String);
            dbPara2.Add("CustomerItemCode", _design.CustomerItemCode, DbType.String);
            dbPara2.Add("Created", _design.Created, DbType.Date);
            dbPara2.Add("Updated", _design.Updated, DbType.Date);
            dbPara2.Add("Archived", _design.Archived, DbType.Boolean);

            var _cloneDesignID = Task.FromResult(_dapperService.Insert<int>("dbo.usp_Design_Add", dbPara2, commandType: CommandType.StoredProcedure));

            return _cloneDesignID;
        }

        public Task<int> GetByKingId(string KingId)
        {
            var dbPara = new DynamicParameters();
            dbPara.Add("KingDesignID", KingId, DbType.String);

            var _cloneId = Task.FromResult(_dapperService.GetID("dbo.usp_Design_GetByKingID", dbPara, commandType: CommandType.StoredProcedure));
            return _cloneId;
        }

        public Task<Design> GetById(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("DesignID", id, DbType.Int32);

            var _design = Task.FromResult(_dapperService.Get<Design>("dbo.usp_Design_GetByID", dbPara, commandType: CommandType.StoredProcedure));

            return _design;
        }

        public Task<int> GetNextId()
        {
            var _nextID = Task.FromResult(_dapperService.GetID("dbo.usp_Designs_GetNextID", null, commandType: CommandType.StoredProcedure));

            return _nextID;
        }

        public Task<int> Delete(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("DesignID", id, DbType.Int32);

            var deleteDesign = Task.FromResult(_dapperService.Execute("dbo.usp_Design_DeleteByID", dbPara, commandType: CommandType.StoredProcedure));

            return deleteDesign;
        }

        /// <summary>
        /// Returns a list of all Designs from the database.
        /// </summary>
        /// <returns></returns>
        public Task<List<Design>> ListAll()
        {
            var _design = Task.FromResult(_dapperService.GetAll<Design>("dbo.usp_Design_GetAll", null, commandType: CommandType.StoredProcedure));

            return _design;
        }

        /// <summary>
        /// Updates the current design in the database.
        /// </summary>
        /// <param name="_design">The current design which is being modified.</param>
        /// <returns></returns>
        public Task<int> Update(Design _design)
        {
            _design.Updated = DateTime.Today;

            var dbPara = new DynamicParameters();

            dbPara.Add("DesignID", _design.DesignID, DbType.Int32);
            dbPara.Add("KingDesignID", _design.KingDesignID, DbType.String);
            dbPara.Add("Item", _design.Item, DbType.String);
            dbPara.Add("Color", _design.Color, DbType.String);
            dbPara.Add("Hold", _design.Hold, DbType.Boolean);
            dbPara.Add("Notes", _design.Notes, DbType.String);
            dbPara.Add("Customer", _design.Customer, DbType.String);
            dbPara.Add("LabelPosition", _design.LabelPosition, DbType.Int32);
            dbPara.Add("Description", _design.Description, DbType.String);
            dbPara.Add("Weight", _design.Weight, DbType.String);
            dbPara.Add("UPC", _design.UPC, DbType.String);
            dbPara.Add("CustomerItemCode", _design.CustomerItemCode, DbType.String);
            dbPara.Add("Created", _design.Created, DbType.Date);
            dbPara.Add("Updated", _design.Updated, DbType.Date);
            dbPara.Add("Archived", _design.Archived, DbType.Boolean);

            var updateDesign = Task.FromResult(_dapperService.Update<int>("dbo.usp_Design_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateDesign;
        }
    }
}
