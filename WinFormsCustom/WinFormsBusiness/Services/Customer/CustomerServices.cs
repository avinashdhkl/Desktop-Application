using DataAccessSqlLite.SqlLite;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsCommon.Model.Common;
using WinFormsCommon.Model.Customer;


namespace WinFormsBusiness.Services.Customer
{
    public class CustomerServices : ICustomerServices
    {
        //private readonly IConfiguration _configuration;
        private const string errorCode = "101";
        private const string successCode = "200";
        private const string Method = "Customer";
        private readonly ILogger _logger = Log.ForContext<CustomerServices>();
        private readonly ISqlLiteDataAccess _sqlLiteDataAccess;
        public CustomerServices(ISqlLiteDataAccess sqlLiteDataAccess)
        {
            this._sqlLiteDataAccess = sqlLiteDataAccess;
        }
        #region DB Connection
        private string GetConnectionString()
        {

            string connectionStrings = ConfigurationManager.ConnectionStrings["connectionstring"]?.ConnectionString;
            return connectionStrings;
        }
        private async Task<DataTable> FetchDataTable(string sqlQuery = "select * from Customer.TBL_CustomerDetails")
        {
            SqlConnection sqlConn = new SqlConnection(GetConnectionString());
            DataTable table = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                await sqlConn.OpenAsync();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {

                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "FetchDataTable", "WFALog", "MSSQlServer", ex.Message, null, null);
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        private async Task<DataTable> FetchDataTableById(int customerId, string sqlQuery = "select * from Customer.TBL_CustomerDetails where CustomerId =@CustomerId")
        {
            SqlConnection sqlConn = new SqlConnection(GetConnectionString());
            DataTable table = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                await sqlConn.OpenAsync();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Error", "FetchDataTableById", "WFALog", "MSSQlServer", ex.Message, null, null);

                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        private async Task<bool> InsertDataTable(CustomerParam customerParam, string sqlQuery = "Insert Into Customer.TBL_CustomerDetails(FullName,Email,PhoneNo,CreatedDate) Values(@FullName,@Email,@PhoneNo,@CreatedDate)")
        {
            bool isSuccess = false;
            SqlConnection sqlConn = new SqlConnection(GetConnectionString());
            //DataTable table = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                cmd.Parameters.AddWithValue("@FullName", customerParam.FullName.Trim());
                cmd.Parameters.AddWithValue("@Email", customerParam.Email.Trim());
                cmd.Parameters.AddWithValue("@PhoneNo", customerParam.PhoneNo.Trim());
                cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                /* SqlDataAdapter adapter = new SqlDataAdapter(cmd);*/
                await sqlConn.OpenAsync();
                int rows = await cmd.ExecuteNonQueryAsync();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "InsertDataTable", "WFALog", "MSSQlServer", ex.Message, JsonConvert.SerializeObject(customerParam), null);
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        private async Task<bool> UpdateDataTable(CustomerParam customerParam, string sqlQuery = "update Customer.TBL_CustomerDetails set FullName=@FullName,Email=@Email,PhoneNo=@PhoneNo,UpdateDate=@UpdateDate where CustomerId=@CustomerId")
        {
            bool isSuccess = false;
            SqlConnection sqlConn = new SqlConnection(GetConnectionString());
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                cmd.Parameters.AddWithValue("@FullName", customerParam.FullName);
                cmd.Parameters.AddWithValue("@Email", customerParam.Email);
                cmd.Parameters.AddWithValue("@PhoneNo", customerParam.PhoneNo);
                cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@CustomerId", customerParam.CustomerId);
                /* SqlDataAdapter adapter = new SqlDataAdapter(cmd);*/
                await sqlConn.OpenAsync();
                int rows = await cmd.ExecuteNonQueryAsync();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                return isSuccess;
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerParam.CustomerId.ToString(), "Error", "UpdateDataTable", "WFALog", "MSSQlServer", ex.Message, JsonConvert.SerializeObject(customerParam), null);
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        private async Task<bool> DeleteDataTable(int customerId, string sqlQuery = "Delete From Customer.TBL_CustomerDetails where CustomerId=@CustomerId")
        {
            bool issuccess = false;
            SqlConnection sqlConn = new SqlConnection(GetConnectionString());
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                await sqlConn.OpenAsync();
                int rows = await cmd.ExecuteNonQueryAsync();
                if (rows > 0)
                {
                    issuccess = true;
                }
                return issuccess;
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Error", "DeleteDataTable", "WFALog", "MSSQlServer", ex.Message, customerId.ToString(), null);
                throw;
            }
            finally { sqlConn.Close(); }
        }
        #endregion DB Connection
        #region Customer
        public async Task<CommonModel> InsertCustomer(CustomerParam customerparam)
        {
            try
            {
                _logger.Information("request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "InsertCustomer", "WFALog", "MSSQlServer", null, JsonConvert.SerializeObject(customerparam), null);
                var resp = await InsertDataTable(customerparam);
                if (resp)
                {
                    /*await _sqlLiteDataAccess.InsertCustomerDataTable(customerparam);*/
                    _logger.Information("Response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", "Success", "Response", "InsertCustomer", "WFALog", "MSSQlServer", null, JsonConvert.SerializeObject(customerparam), JsonConvert.SerializeObject(resp));
                    return new CommonModel
                    {
                        Code = "200",
                        Message = "Insert Successfull",
                    };
                }
                _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerparam.CustomerId.ToString(), "Response", "UpdateCustomer", "WFALog", "MSSQlServer", "Insert Process is Incomplete", JsonConvert.SerializeObject(customerparam), JsonConvert.SerializeObject(resp));
                return new CommonModel
                {
                    Code = "101",
                    Message = "Insert Process is Incomplete",
                };
            }
            catch (Exception ex)
            {
                _logger.Information("Error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", ex.Message, "Error", "InsertCustomer", "WFALog", "MSSQlServer", null, JsonConvert.SerializeObject(customerparam), null);
                return new CommonModel
                {
                    Code = "101",
                    Message = ex.Message,
                };


            }
        }
        public async Task<CommonModel> UpdateCustomer(CustomerParam customerparam)
        {
            try
            {
                _logger.Information("request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerparam.CustomerId.ToString(), "Request", "UpdateCustomer", "WFALog", "MSSQlServer", null, JsonConvert.SerializeObject(customerparam), null);
                var resp = await UpdateDataTable(customerparam);
                if (resp)
                {
                    await _sqlLiteDataAccess.UpdateCustomerDataTable(customerparam);
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerparam.CustomerId.ToString(), "Response", "UpdateCustomer", "WFALog", "MSSQlServer", "Success", JsonConvert.SerializeObject(customerparam), JsonConvert.SerializeObject(resp));
                    return new CommonModel
                    {
                        Code = "200",
                        Message = "Update Successfull",
                    };
                }
                _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerparam.CustomerId.ToString(), "Response", "UpdateCustomer", "WFALog", "MSSQlServer", "Update Process is Incomplete", JsonConvert.SerializeObject(customerparam), JsonConvert.SerializeObject(resp));
                return new CommonModel
                {
                    Code = "101",
                    Message = "Update Process is Incomplete",
                };
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerparam.CustomerId.ToString(), "Error", "UpdateCustomer", "WFALog", "MSSQlServer", ex.Message, JsonConvert.SerializeObject(customerparam), null);
                return new CommonModel
                {
                    Code = "101",
                    Message = ex.Message,
                };


            }
        }
        public async Task<CustomerModel> FetchAllCustomerDetails()
        {
            try
            {
                CustomerModel customermodel = new CustomerModel();
                List<CustomerParam> CustomerList = new List<CustomerParam>();
                _logger.Information("request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "FetchAllCustomerDetails", "WFALog", "MSSQlServer", null, null, null);
                var resp = await FetchDataTable();
                var fetchAll = await _sqlLiteDataAccess.FetchAllCustomerDetails();
                foreach (DataRow row in resp.Rows)
                {
                    var customerparam = new CustomerParam()
                    {
                        FullName = row["FullName"].ToString(),
                        Email = row["Email"].ToString().Trim(),
                        PhoneNo = row["PhoneNo"].ToString(),
                        CustomerId = Convert.ToInt32(row["CustomerId"]),
                        CreatedDate = row["CreatedDate"].ToString(),
                        UpdateDate = row["UpdateDate"].ToString(),
                    };
                    CustomerList.Add(customerparam);
                }
                customermodel.CustomerList = CustomerList;
                _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Response", "FetchAllCustomerDetails", "WFALog", "MSSQlServer", "Success", null, JsonConvert.SerializeObject(CustomerList));
                return customermodel;
            }
            catch (Exception ex)
            {
                _logger.Error("Error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "FetchAllCustomerDetails", "WFALog", "MSSQlServer", ex.Message, null, null);
                return new CustomerModel
                {
                    Code = errorCode,
                    Message = ex.Message,
                };
            }
        }
        public async Task<CustomerModel> FetchCustomerDetailsById(int customerId)
        {
            try
            {
                CustomerModel customermodel = new CustomerModel();
                _logger.Information("request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Request", "FetchCustomerDetailsById", "WFALog", "MSSQlServer", null, JsonConvert.SerializeObject(customerId.ToString()), null);
                //     _log.Information("response returned as {Area}{Controller}{Action}{LogType}{Key}{UserName}{StoreProcedure}{Flag}{ReferenceNo}{Param}"
                //, logModel.Area, logModel.Controller, logModel.Action, dbResponseMethod, key, logModel.UserName, procedureName, logModel.Flag, logModel.ReferenceNo, JsonConvert.SerializeObject(response));
                var resp = await FetchDataTableById(customerId);
                _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Response", "FetchCustomerDetailsById", "WFALog", "MSSQlServer", "Success", JsonConvert.SerializeObject(customerId.ToString()), JsonConvert.SerializeObject(resp));
                CustomerParam CustomerParam = new CustomerParam();
                foreach (DataRow row in resp.Rows)
                {
                    CustomerParam.FullName = row["FullName"].ToString();
                    CustomerParam.Email = row["Email"].ToString();
                    CustomerParam.PhoneNo = row["PhoneNo"].ToString();
                    CustomerParam.CustomerId = Convert.ToInt32(row["CustomerId"]);
                }
                //var getCustomerDetails = await _sqlLiteDataAccess.FetchCustomerDetailsById(customerId);
                //if (getCustomerDetails.CustomerDetails.CustomerId == 0)
                //{

                //    await _sqlLiteDataAccess.InsertCustomerDataTable(CustomerParam);
                //}

                customermodel.CustomerDetails = CustomerParam;
                return customermodel;
            }
            catch (Exception ex)
            {
                _logger.Error("Error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Error", "FetchCustomerDetailsById", "WFALog", "MSSQlServer", JsonConvert.SerializeObject(ex.Message), JsonConvert.SerializeObject(customerId.ToString()), null);
                return new CustomerModel
                {
                    Code = errorCode,
                    Message = ex.Message,
                };
            }
        }
        public async Task<CommonModel> DeleteCustomer(int customerId)
        {
            try
            {
                _logger.Information("request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Request", "DeleteCustomer", "WFALog", "MSSQlServer", null, customerId.ToString(), null);
                var resp = await DeleteDataTable(customerId);
                if (resp)
                {
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Response", "DeleteCustomer", "WFALog", "MSSQlServer", "Success", customerId.ToString(), resp);
                    return new CustomerModel
                    {
                        Code = successCode,
                        Message = "Delete Successful",
                    };
                }
                _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Response", "DeleteCustomer", "WFALog", "MSSQlServer", "Delete process incomplete", customerId.ToString(), resp);
                return new CustomerModel
                {
                    Code = errorCode,
                    Message = "Delete process incomplete",
                };
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Error", "DeleteCustomer", "WFALog", "MSSQlServer", ex.Message, customerId.ToString(), null);
                return new CustomerModel
                {
                    Code = errorCode,
                    Message = ex.Message,
                };
            }
        }
        public async void synch_InsertCustomer()
        {
            try
            {
                _logger.Information("request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "synch_InsertCustomer", "WFALog", "sqlLite", null, null, null);
                var fetchallcustomerdetails = await FetchAllCustomerDetails();
                if (fetchallcustomerdetails.CustomerList != null)
                {
                    foreach (var item in fetchallcustomerdetails.CustomerList)
                    {
                        var fetchById = await _sqlLiteDataAccess.FetchCustomerDetailsById(item.CustomerId);
                        if (fetchById.CustomerDetails.CustomerId <= 0)
                        {
                            //Thread.Sleep(120000);
                            await _sqlLiteDataAccess.InsertCustomerDataTable(item);
                        }
                    }
                   
                }
               
            }
            catch (Exception ex)
            {
                _logger.Information("Error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", ex.Message, "Error", "synch_InsertCustomer", "WFALog", "sqlLite", null, null, null);               


            }
        }
        #endregion Customer
    }
}
