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
    /// <summary>
    /// Represents the database services for managing the Product
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IDapperService _dapperService;

        /// <summary>
        /// Initializes a new ProductService. 
        /// </summary>
        /// <param name="dapperService">The delegate that represents the Dapper Service database connection mechanism.</param>
        public ProductService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }

        /// <summary>
        /// Creates a new Product that is added to the database.
        /// </summary>
        /// <param name="_product">Represents the object model of the Product to be added.</param>
        /// <returns>The ID value of the newly created Product.</returns>
        public Task<int> Create(Product _product)
        {
            _product.Created = DateTime.Today;
            _product.Updated = DateTime.Today;

            var dbPara = new DynamicParameters();

            dbPara.Add("ProductName", _product.ProductName, DbType.String);
            dbPara.Add("Type", _product.Type, DbType.String);
            dbPara.Add("Description", _product.Description, DbType.String);
            dbPara.Add("Created", _product.Created, DbType.Date);
            dbPara.Add("Updated", _product.Updated, DbType.Date);
            dbPara.Add("Archived", _product.Archived, DbType.Boolean);

            var _productID = Task.FromResult(_dapperService.Insert<int>("dbo.usp_Product_Add", dbPara, commandType: CommandType.StoredProcedure));

            return _productID;
        }

        /// <summary>
        /// Gets a specific Product from the database.
        /// </summary>
        /// <param name="id">The ID value of the Product that is to be retrieved from the database.</param>
        /// <returns>A object of the specific Product.</returns>
        public Task<Product> GetById(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("ProductID", id, DbType.Int16);

            var _product = Task.FromResult(_dapperService.Get<Product>("dbo.usp_Product_GetByID", dbPara, commandType: CommandType.StoredProcedure));

            return _product;
        }

        public Task<String> GetTypeByName(string name)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("ProductName", name, DbType.String);

            var _productType = Task.FromResult(_dapperService.Get<String>("dbo.usp_Product_GetTypeByName", dbPara, commandType: CommandType.StoredProcedure));

            return _productType;
        }

        /// <summary>
        /// Deletes the current Product from the database.
        /// </summary>
        /// <param name="id">The ID value of the Product to be deleted.</param>
        /// <returns>The successfully completed delete task.</returns>
        public Task<int> Delete(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("ProductID", id, DbType.Int16);

            var deleteProduct = Task.FromResult(_dapperService.Execute("dbo.usp_Product_DeleteByID", dbPara, commandType: CommandType.StoredProcedure));

            return deleteProduct;
        }

        /// <summary>
        /// Returns a list of all Products in the database.
        /// </summary>
        /// <returns>The list of all Products.</returns>
        public Task<List<Product>> ListAll()
        {
            var _product = Task.FromResult(_dapperService.GetAll<Product>("dbo.usp_Product_GetAll", null, commandType: CommandType.StoredProcedure));

            return _product;
        }

        /// <summary>
        /// Updates the current Product in the database.  
        /// </summary>
        /// <param name="_product">Represents the object model of the Product to be updated.</param>
        /// <returns>The successfully completed update task.</returns>
        public Task<int> Update(Product _product)
        {
            _product.Updated = DateTime.Today;

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