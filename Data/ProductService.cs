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
    public class ProductService : IProductService
    {
        private readonly IDapperService _dapperService;

        public ProductService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }

        public Task<int> Create(Product _product)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("Name", _product.ProductName, DbType.String);
            dbPara.Add("Type", _product.Type, DbType.String);
            dbPara.Add("Type", _product.Description, DbType.String);
            dbPara.Add("Notes1", _product.Created, DbType.Date);
            dbPara.Add("Notes2", _product.Updated, DbType.Date);
            dbPara.Add("Type", _product.Archived, DbType.Boolean);

            var _productID = Task.FromResult(_dapperService.Insert<int>("dbo.usp_Product_Add", dbPara, commandType: CommandType.StoredProcedure));

            return _productID;
        }

        public Task<Product> GetById(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("CustomerID", id, DbType.Int16);

            var _product = Task.FromResult(_dapperService.Get<Product>("dbo.usp_Product_GetByID", dbPara, commandType: CommandType.StoredProcedure));

            return _product;
        }

        public Task<int> Delete(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("CustomerID", id, DbType.Int16);

            var deleteProduct = Task.FromResult(_dapperService.Execute("dbo.usp_Product_DeleteByID", dbPara, commandType: CommandType.StoredProcedure));

            return deleteProduct;
        }

        public Task<List<Product>> ListAll()
        {
            var _product = Task.FromResult(_dapperService.GetAll<Product>("dbo.usp_Product_GetAll", null, commandType: CommandType.StoredProcedure));

            return _product;
        }

        public Task<int> Update(Product _product)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("ProductID", _product.ProductID, DbType.Int16);
            dbPara.Add("ProductName", _product.ProductName, DbType.String);
            dbPara.Add("Type", _product.Type, DbType.String);
            dbPara.Add("Description", _product.Description, DbType.String);
            dbPara.Add("Created", _product.Created, DbType.Date);
            dbPara.Add("Updated", _product.Updated, DbType.Date);
            dbPara.Add("Archived", _product.Archived, DbType.Boolean);

            var updateProduct = Task.FromResult(_dapperService.Update<int>("dbo.usp_Product_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateProduct;
        }
    }
}