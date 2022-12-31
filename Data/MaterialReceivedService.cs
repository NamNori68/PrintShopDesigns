using PrintShopDesigns.Interfaces;
using PrintShopDesigns.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PrintShopDesigns.Data
{
	public class MaterialReceivedService : IMaterialReceivedService
	{
		private readonly IDapperService _dapperService;

		public MaterialReceivedService(IDapperService dapperService)
		{
			this._dapperService = dapperService;
		}

		public Task<int> Create(MaterialReceived materialReceived)
		{
			var dbPara = new DynamicParameters();

			dbPara.Add("Name", materialReceived.Name, DbType.String);
			dbPara.Add("Type", materialReceived.Type, DbType.String);
			dbPara.Add("KingLot", materialReceived.KingLot, DbType.String);
			dbPara.Add("VendorLot", materialReceived.VendorLot, DbType.String);
			dbPara.Add("Quantity", materialReceived.Quantity, DbType.Int16);
			dbPara.Add("CostLb", materialReceived.CostLb, DbType.Double);
			dbPara.Add("Notes", materialReceived.Notes, DbType.String);


			var MaterialReceivedId = Task.FromResult(_dapperService.Insert<int>("dbo.usp_MaterialReceived_Add", dbPara, commandType: CommandType.StoredProcedure));

			return MaterialReceivedId;
		}

		public Task<MaterialReceived> GetById(int id)
		{
			var dbPara = new DynamicParameters();

			dbPara.Add("MaterialReceivedID", id, DbType.Int16);

			var MaterialReceived = Task.FromResult(_dapperService.Get<MaterialReceived>("dbo.usp_MaterialReceived_GetByID", dbPara, commandType: CommandType.StoredProcedure));

			return MaterialReceived;
		}

		public Task<int> Delete(int id)
		{
			var dbPara = new DynamicParameters();

			dbPara.Add("MaterialReceivedID", id, DbType.Int16);

			var deleteMaterial = Task.FromResult(_dapperService.Execute("dbo.usp_MaterialReceived_DeleteByID", dbPara, commandType: CommandType.StoredProcedure));

			return deleteMaterial;
		}

		public Task<List<MaterialReceived>> ListAll()
		{
			var materialReceived = Task.FromResult(_dapperService.GetAll<MaterialReceived>("dbo.usp_MaterialReceived_GetAll", null, commandType: CommandType.StoredProcedure));

			return materialReceived;
		}

		public Task<int> Update(MaterialReceived materialReceived)
		{
			var dbPara = new DynamicParameters();

			dbPara.Add("MaterialReceivedID", materialReceived.MaterialReceivedID, DbType.Int16);
			dbPara.Add("Name", materialReceived.Name, DbType.String);
			dbPara.Add("Type", materialReceived.Type, DbType.String);
			dbPara.Add("KingLot", materialReceived.KingLot, DbType.String);
			dbPara.Add("VendorLot", materialReceived.VendorLot, DbType.String);
			dbPara.Add("Quantity", materialReceived.Quantity, DbType.Int16);
			dbPara.Add("CostLb", materialReceived.CostLb, DbType.Double);
			dbPara.Add("Notes", materialReceived.Notes, DbType.String);

			var updateMaterial = Task.FromResult(_dapperService.Update<int>("dbo.usp_MaterialReceived_Update", dbPara, commandType: CommandType.StoredProcedure));

			return updateMaterial;
		}
	}
}