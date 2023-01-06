using PrintShopDesigns.Interfaces;
using PrintShopDesigns.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PrintShopDesigns.Data
{
    public class CustomerService : ICustomerService
    {
        private readonly IDapperService _dapperService;

        public CustomerService(IDapperService dapperService)
        {
            this._dapperService = dapperService;
        }

        public Task<int> Create(Customer _customer)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("CustomerName", _customer.CustomerName, DbType.String);
            dbPara.Add("Address", _customer.Address, DbType.String);
            dbPara.Add("Address2", _customer.Address2, DbType.String);
            dbPara.Add("City", _customer.City, DbType.String);
            dbPara.Add("State", _customer.State, DbType.String);
            dbPara.Add("Zip", _customer.Zip, DbType.String);

            var CustomerID = Task.FromResult(_dapperService.Insert<int>("dbo.usp_Customer_Add", dbPara, commandType: CommandType.StoredProcedure));

            return CustomerID;
        }

        public Task<Customer> GetById(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("CustomerID", id, DbType.Int16);

            var _customer = Task.FromResult(_dapperService.Get<Customer>("dbo.usp_Customer_GetByID", dbPara, commandType: CommandType.StoredProcedure));

            return _customer;
        }

        public Task<int> Delete(int id)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("CustomerID", id, DbType.Int16);

            var deleteCustomer = Task.FromResult(_dapperService.Execute("dbo.usp_Customer_DeleteByID", dbPara, commandType: CommandType.StoredProcedure));

            return deleteCustomer;
        }

        public Task<List<Customer>> ListAll()
        {
            var _customer = Task.FromResult(_dapperService.GetAll<Customer>("dbo.usp_Customer_GetAll", null, commandType: CommandType.StoredProcedure));

            return _customer;
        }

        public Task<int> Update(Customer _customer)
        {
            var dbPara = new DynamicParameters();

            dbPara.Add("CustomerID", _customer.CustomerID, DbType.Int16);
            dbPara.Add("CustomerName", _customer.CustomerName, DbType.String);
            dbPara.Add("Address", _customer.Address, DbType.String);
            dbPara.Add("Address2", _customer.Address2, DbType.String);
            dbPara.Add("City", _customer.City, DbType.String);
            dbPara.Add("State", _customer.State, DbType.String);
            dbPara.Add("Zip", _customer.Zip, DbType.String);

            var updateCustomer = Task.FromResult(_dapperService.Update<int>("dbo.usp_Customer_Update", dbPara, commandType: CommandType.StoredProcedure));

            return updateCustomer;
        }
    }
}