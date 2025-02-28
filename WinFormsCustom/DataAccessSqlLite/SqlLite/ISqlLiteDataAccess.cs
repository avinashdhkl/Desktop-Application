using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsBusiness.Model.Location;
using WinFormsCommon.Model.Customer;



namespace DataAccessSqlLite.SqlLite
{
    public interface ISqlLiteDataAccess
    {
        #region Customer
         Task<bool> InsertCustomerDataTable(CustomerParam customerParam, string sqlQuery = "Insert Into TBL_CustomerDetails(CustomerId,FullName,Email,PhoneNo,CreatedDate) Values(@CustomerId,@FullName,@Email,@PhoneNo,@CreatedDate)");
         Task<bool> UpdateCustomerDataTable(CustomerParam customerParam, string sqlQuery = "update TBL_CustomerDetails set FullName=@FullName,Email=@Email,PhoneNo=@PhoneNo,UpdateDate=@UpdateDate where CustomerId=@CustomerId");
         Task<CustomerModel> FetchCustomerDetailsById(int customerId);
        Task<CustomerModel> FetchAllCustomerDetails();
        Task<bool> DeleteCustomerDataTable(int customerId, string sqlQuery = "Delete From TBL_CustomerDetails where CustomerId=@CustomerId");
        #endregion Customer
        #region Location
        Task<bool> InsertLocationDataTable(LocationParam locationparam, string sqlQuery = "Insert Into TBL_LocationDetail(LocationId,Address,CustomerId,CreatedDate) Values(@LocationId,@Address,@CustomerId,@CreatedDate)");
        Task<bool> UpdateLocationDataTable(LocationParam locationparam, string sqlQuery = "Update TBL_LocationDetail Address=@Address,CustomerId=@CustomerId,UpdateDate=@UpdateDate where LocationId=@LocationId");
        Task<bool> DeleteLocationDataTable(int locationId, string sqlQuery = "Delete From TBL_LocationDetail where LocationId=@LocationId");
        Task<LocationModel> FetchLocationDetailsById(int locationId);
        Task<LocationModel> FetchLocationAllDetails();
        #endregion Location
    }
}
