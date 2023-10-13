using PrintShopDesigns.Interfaces;
using PrintShopDesigns.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PrintShopDesigns.Data
{
    public class MachineService : iMachineService
    {
        private readonly IDapperService _dapperService;

        public MachineService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }

        public Task<List<Machine>> ListAll()
        {
            var _machines = Task.FromResult(_dapperService.GetAll<Machine>("dbo.usp_Machines_GetAll_Label", null, commandType: CommandType.StoredProcedure));

            return _machines;
        }

        public Task<List<Machine>> ListAllLabel()
        {
            var _machines = Task.FromResult(_dapperService.GetAll<Machine>("dbo.usp_Machines_GetAll_Label", null, commandType: CommandType.StoredProcedure));

            return _machines;
        }

        public Task<List<Machine>> ListAllUsed(int _designId)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("DesignId", _designId, DbType.Int32);

            var _usedMachines = Task.FromResult(_dapperService.GetAll<Machine>("dbo.usp_Machines_GetByDesignId", dbPara, commandType: CommandType.StoredProcedure));

            return _usedMachines;
        }

        public Task<int> Clear(Int32 _designID)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("DesignID", _designID, DbType.Int32);

            var addMachine = Task.FromResult(_dapperService.Update<int>("dbo.usp_DesignMachines_Clear", dbPara, commandType: CommandType.StoredProcedure));

            return addMachine;
        }

        public Task<Int32> Add(Int32 _machineID, Int32 _designID)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("MachineID", _machineID, DbType.Int32);
            dbPara.Add("DesignID", _designID, DbType.Int32);

            var addMachine = Task.FromResult(_dapperService.Update<int>("dbo.usp_DesignMachines_Add", dbPara, commandType: CommandType.StoredProcedure));

            return addMachine;
         }
    }
}
