using PrintShopDesigns.Interfaces;
using PrintShopDesigns.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PrintShopDesigns.Data
{
    public class ColorService : iColorService
    {
        private readonly IDapperService _dapperService;

        public ColorService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }

        public Task<List<Color>> ListAll()
        {
            var _color = Task.FromResult(_dapperService.GetAll<Color>("dbo.usp_Colors_GetAll", null, commandType: CommandType.StoredProcedure));

            return _color;
        }
    }
}
