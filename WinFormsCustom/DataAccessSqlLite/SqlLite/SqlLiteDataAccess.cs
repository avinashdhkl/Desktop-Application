using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WinFormsBusiness.Model.Location;
using WinFormsCommon.Model.Customer;


namespace DataAccessSqlLite.SqlLite
{
    public class SqlLiteDataAccess : ISqlLiteDataAccess
    {
        private readonly ILogger _logger = Log.ForContext<SqlLiteDataAccess>();
        private const string PRAGMATimeOut = "PRAGMA busy_timeout = 3000;";
        private string GetConnecionString()
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["SqlLiteconnectionstring"].ConnectionString;
            return connectionstring;
        }
        #region Customer
        public async Task<bool> InsertCustomerDataTable(CustomerParam customerParam, string sqlQuery = "Insert Into TBL_CustomerDetails(CustomerId,FullName,Email,PhoneNo,CreatedDate) Values(@CustomerId,@FullName,@Email,@PhoneNo,@CreatedDate)")
        {
            bool isSuccess = false;
            using (SQLiteConnection sqlConn = new SQLiteConnection(GetConnecionString()))
            {
                //using (var transaction = sqlConn.BeginTransaction())
                //{
                try
                {

                    sqlConn.Open();
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "InsertCustomerDataTable", "WFALog", "SqlLite", null, JsonConvert.SerializeObject(customerParam), null);
                    using (SQLiteCommand cmd = new SQLiteCommand(string.Concat(sqlQuery, ";", PRAGMATimeOut, ";", "PRAGMA journal_mode=WAL"), sqlConn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customerParam.CustomerId);
                        cmd.Parameters.AddWithValue("@FullName", customerParam.FullName);
                        cmd.Parameters.AddWithValue("@Email", customerParam.Email);
                        cmd.Parameters.AddWithValue("@PhoneNo", customerParam.PhoneNo);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);


                        //SetBusyTimeout();
                        int rows = await cmd.ExecuteNonQueryAsync();
                        if (rows > 0)
                        {
                            isSuccess = true;
                        }
                    }
                    /*  transaction.Commit();*/
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "response", "InsertCustomerDataTable", "WFALog", "SqlLite", "Insert Success", JsonConvert.SerializeObject(customerParam), isSuccess);
                    return isSuccess;


                }
                catch (Exception ex)
                {
                    /*transaction.Rollback();*/
                    _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "InsertCustomerDataTable", "WFALog", "SqlLite", ex.Message, JsonConvert.SerializeObject(customerParam), null);
                    throw;
                }
                finally
                {
                    sqlConn.Close();
                    sqlConn.Dispose();
                }
                /*  }*/
            }

        }
        public async Task<bool> UpdateCustomerDataTable(CustomerParam customerParam, string sqlQuery = "update TBL_CustomerDetails set FullName=@FullName,Email=@Email,PhoneNo=@PhoneNo,UpdateDate=@UpdateDate where CustomerId=@CustomerId")
        {
            bool isSuccess = false;
            SQLiteConnection sqlConn = new SQLiteConnection(GetConnecionString());
            try
            {
                sqlConn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(string.Concat(sqlQuery, ";", PRAGMATimeOut, ";", "PRAGMA journal_mode=WAL"), sqlConn))
                {
                    cmd.Parameters.AddWithValue("@FullName", customerParam.FullName);
                    cmd.Parameters.AddWithValue("@Email", customerParam.Email);
                    cmd.Parameters.AddWithValue("@PhoneNo", customerParam.PhoneNo);
                    cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CustomerId", customerParam.CustomerId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        isSuccess = true;
                    }
                }

                return isSuccess;
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "UpdateCustomerDataTable", "WFALog", "SqlLite", ex.Message, JsonConvert.SerializeObject(customerParam), null);
                throw;
            }
            finally
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
        private async Task<DataTable> FetchDetailsById(int customerId, string sqlQuery = "select * from TBL_CustomerDetails where CustomerId =@CustomerId")
        {
            using (SQLiteConnection sqlConnect = new SQLiteConnection(GetConnecionString()))
            {
                DataTable datatable = new DataTable();
                try
                {
                    sqlConnect.Open();
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Request", "FetchCustomerDetailsById", "WFALog", "SqlLite", null, JsonConvert.SerializeObject(customerId.ToString()), null);
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(string.Concat(sqlQuery, ";", PRAGMATimeOut, ";", "PRAGMA journal_mode=WAL"), sqlConnect))
                    {
                        sqlCmd.Parameters.AddWithValue("@CustomerId", customerId);
                        //sqlCmd.ExecuteNonQuery();                       
                        using (SQLiteDataReader reader = sqlCmd.ExecuteReader())
                        {
                            // Load the data from the reader into the DataTable
                            datatable.Load(reader);
                        }
                        return datatable;
                    }

                }
                catch (Exception ex)
                {
                    _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Error", "FetchCustomerDetailsById", "WFALog", "SqlLite", ex.Message, JsonConvert.SerializeObject(customerId.ToString()), null);

                    throw;
                }
                finally
                {
                    /* transaction.Rollback();*/
                    sqlConnect.Close();
                    //sqlConnect.Dispose();
                }
                /*  }*/

            }

        }
        private async Task<DataTable> FetchAllDetails(string sqlQuery = "select * from TBL_CustomerDetails")
        {
            using (SQLiteConnection sqlConnect = new SQLiteConnection(GetConnecionString()))
            {
                //using (var transaction = sqlConnect.BeginTransaction())
                //{
                DataTable table = new DataTable();
                try
                {
                    sqlConnect.Open();
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "FetchCustomerDetailsById", "WFALog", "SqlLite", null, null, null);
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(string.Concat(sqlQuery, ";", PRAGMATimeOut, ";", "PRAGMA journal_mode=WAL"), sqlConnect))
                    {
                        sqlCmd.ExecuteNonQuery();
                        using (SQLiteDataReader reader = sqlCmd.ExecuteReader())
                        {
                            // Load the data from the reader into the DataTable
                            table.Load(reader);
                        }

                        return table;
                    }

                }
                catch (Exception ex)
                {
                    _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "FetchCustomerDetailsById", "WFALog", "SqlLite", ex.Message, null, null);

                    throw;
                }
                finally
                {
                    /* transaction.Rollback();*/
                    sqlConnect.Close();
                    sqlConnect.Dispose();
                }
                /*  }*/

            }
        }
        public async Task<CustomerModel> FetchCustomerDetailsById(int customerId)
        {
            try
            {
                CustomerModel customers = new CustomerModel();
                var fetchdetailsbyid = await FetchDetailsById(customerId);
                CustomerParam CustomerParam = new CustomerParam();

                foreach (DataRow row in fetchdetailsbyid.Rows)
                {
                    CustomerParam.FullName = string.IsNullOrEmpty(row["FullName"].ToString()) ? null : row["FullName"].ToString();
                    CustomerParam.Email = string.IsNullOrEmpty(row["Email"].ToString()) ? null : row["Email"].ToString();
                    CustomerParam.PhoneNo = string.IsNullOrEmpty(row["PhoneNo"].ToString()) ? null : row["PhoneNo"].ToString();
                    CustomerParam.CustomerId = Convert.ToInt32(row["CustomerId"]) > 0 ? Convert.ToInt32(row["CustomerId"]) : 0;
                }


                customers.CustomerDetails = CustomerParam;
                return customers;
            }
            catch (Exception ex)
            {

                return new CustomerModel
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
                CustomerModel customers = new CustomerModel();
                var fetchdetailsbyid = await FetchAllDetails();
                List<CustomerParam> customerList = new List<CustomerParam>();
                foreach (DataRow row in fetchdetailsbyid.Rows)
                {
                    CustomerParam CustomerParam = new CustomerParam();
                    CustomerParam.FullName = row["FullName"].ToString();
                    CustomerParam.Email = row["Email"].ToString();
                    CustomerParam.PhoneNo = row["PhoneNo"].ToString();
                    CustomerParam.CustomerId = Convert.ToInt32(row["CustomerId"]);
                    customerList.Add(CustomerParam);
                }
                customers.CustomerList = customerList;
                return customers;
            }
            catch (Exception ex)
            {

                return new CustomerModel
                {
                    Code = "101",
                    Message = ex.Message,
                };
            }
        }
        public async Task<bool> DeleteCustomerDataTable(int customerId, string sqlQuery = "Delete From TBL_CustomerDetails where CustomerId=@CustomerId")
        {
            bool isSuccess = false;
            SQLiteConnection sqlConn = new SQLiteConnection(GetConnecionString());
            try
            {
                sqlConn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(string.Concat(sqlQuery, ";", PRAGMATimeOut, ";", "PRAGMA journal_mode=WAL"), sqlConn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    int rows = await cmd.ExecuteNonQueryAsync();
                    if (rows > 0)
                    {
                        isSuccess = true;
                    }
                }

                return isSuccess;
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Error", "DeleteCustomerDataTable", "WFALog", "SqlLite", ex.Message, null, null);
                throw;
            }
            finally
            {
                sqlConn.Close();
                sqlConn.Dispose();
            }
        }
        #endregion Customer
        #region Location
        public async Task<bool> InsertLocationDataTable(LocationParam locationparam, string sqlQuery = "Insert Into TBL_LocationDetail(LocationId,Address,CustomerId,CreatedDate) Values(@LocationId,@Address,@CustomerId,@CreatedDate)")
        {
            bool isSuccess = false;
            using (SQLiteConnection sqlConn = new SQLiteConnection(GetConnecionString()))
            {
                //using (var transaction = sqlConn.BeginTransaction())
                //{
                try
                {

                    sqlConn.Open();
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "InsertLocationDataTable", "WFALog", "SqlLite", null, JsonConvert.SerializeObject(locationparam), null);
                    using (SQLiteCommand cmd = new SQLiteCommand(string.Concat(sqlQuery, ";", PRAGMATimeOut, ";", "PRAGMA journal_mode=WAL"), sqlConn))
                    {
                        cmd.Parameters.AddWithValue("@LocationId", locationparam.LocationId);
                        cmd.Parameters.AddWithValue("@Address", locationparam.Address);
                        cmd.Parameters.AddWithValue("@CustomerId", locationparam.CustomerId);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        int rows = await cmd.ExecuteNonQueryAsync();
                        if (rows > 0)
                        {
                            isSuccess = true;
                        }
                    }
                    
                    /*  transaction.Commit();*/
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Response", "InsertLocationDataTable", "WFALog", "SqlLite", "Insert Success", JsonConvert.SerializeObject(locationparam), isSuccess);
                    return isSuccess;


                }
                catch (Exception ex)
                {
                    /*transaction.Rollback();*/
                    _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "InsertLocationDataTable", "WFALog", "SqlLite", ex.Message, JsonConvert.SerializeObject(locationparam), null);
                    throw;
                }
                finally
                {
                    sqlConn.Close();
                    sqlConn.Dispose();
                }
                /*  }*/
            }
        }
        public async Task<bool> UpdateLocationDataTable(LocationParam locationparam, string sqlQuery = "Update TBL_LocationDetail Address=@Address,CustomerId=@CustomerId,UpdateDate=@UpdateDate where LocationId=@LocationId")
        {
            bool isSuccess = false;
            using (SQLiteConnection sqlConn = new SQLiteConnection(GetConnecionString()))
            {
                //using (var transaction = sqlConn.BeginTransaction())
                //{
                try
                {

                    sqlConn.Open();
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "UpdateLocationDataTable", "WFALog", "SqlLite", null, JsonConvert.SerializeObject(locationparam), null);
                    using (SQLiteCommand cmd = new SQLiteCommand(string.Concat(sqlQuery, ";", PRAGMATimeOut, ";", "PRAGMA journal_mode=WAL"), sqlConn))
                    {
                        cmd.Parameters.AddWithValue("@Address", locationparam.Address);
                        cmd.Parameters.AddWithValue("@CustomerId", locationparam.CustomerId);
                        cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@LocationId", locationparam.LocationId);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            isSuccess = true;
                        }
                    }
                    /*  transaction.Commit();*/
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "UpdateLocationDataTable", "WFALog", "SqlLite", "update Success", JsonConvert.SerializeObject(locationparam), isSuccess);
                    return isSuccess;


                }
                catch (Exception ex)
                {
                    /*transaction.Rollback();*/
                    _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "UpdateLocationDataTable", "WFALog", "SqlLite", ex.Message, JsonConvert.SerializeObject(locationparam), null);
                    throw;
                }
                finally
                {
                    sqlConn.Close();
                    sqlConn.Dispose();
                }
                /*  }*/
            }
        }
        public async Task<bool> DeleteLocationDataTable(int locationId, string sqlQuery = "Delete From TBL_LocationDetail where LocationId=@LocationId")
        {
            bool isSuccess = false;
            using (SQLiteConnection sqlConn = new SQLiteConnection(GetConnecionString()))
            {
                //using (var transaction = sqlConn.BeginTransaction())
                //{
                try
                {

                    sqlConn.Open();
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Request", "DeleteLocationDataTable", "WFALog", "SqlLite", null, JsonConvert.SerializeObject(locationId), null);
                    using (SQLiteCommand cmd = new SQLiteCommand(string.Concat(sqlQuery, ";", PRAGMATimeOut, ";", "PRAGMA journal_mode=WAL"), sqlConn))
                    {
                        cmd.Parameters.AddWithValue("@LocationId", locationId);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            isSuccess = true;
                        }
                    }
                    /*  transaction.Commit();*/
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Request", "DeleteLocationDataTable", "WFALog", "SqlLite", "update Success", JsonConvert.SerializeObject(locationId), isSuccess);
                    return isSuccess;


                }
                catch (Exception ex)
                {
                    /*transaction.Rollback();*/
                    _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Error", "DeleteLocationDataTable", "WFALog", "SqlLite", ex.Message, JsonConvert.SerializeObject(locationId), null);
                    throw;
                }
                finally
                {
                    sqlConn.Close();
                    sqlConn.Dispose();
                }
                /*  }*/
            }
        }
        private async Task<DataTable> FetchDetailsByLocationId(int locationId, string sqlQuery = "select * from TBL_LocationDetail where LocationId =@LocationId")
        {
            using (SQLiteConnection sqlConnect = new SQLiteConnection(GetConnecionString()))
            {
                DataTable datatable = new DataTable();
                try
                {
                    sqlConnect.Open();
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Request", "FetchCustomerDetailsById", "WFALog", "SqlLite", null, JsonConvert.SerializeObject(locationId.ToString()), null);
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(string.Concat(sqlQuery, ";", PRAGMATimeOut, ";", "PRAGMA journal_mode=WAL"), sqlConnect))
                    {
                        sqlCmd.Parameters.AddWithValue("@LocationId", locationId);
                        //sqlCmd.ExecuteNonQuery();                       
                        using (SQLiteDataReader reader = sqlCmd.ExecuteReader())
                        {
                            // Load the data from the reader into the DataTable
                            datatable.Load(reader);
                        }
                        return datatable;
                    }

                }
                catch (Exception ex)
                {
                    _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Error", "FetchCustomerDetailsById", "WFALog", "SqlLite", ex.Message, JsonConvert.SerializeObject(locationId.ToString()), null);

                    throw;
                }
                finally
                {
                    /* transaction.Rollback();*/
                    sqlConnect.Close();
                    //sqlConnect.Dispose();
                }
                /*  }*/

            }

        }
        private async Task<DataTable> FetchLocationAllDetail(string sqlQuery = "select * from TBL_LocationDetail")
        {
            using (SQLiteConnection sqlConnect = new SQLiteConnection(GetConnecionString()))
            {
                DataTable datatable = new DataTable();
                try
                {
                    sqlConnect.Open();
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "FetchAllDetails", "WFALog", "SqlLite", null, null, null);
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(string.Concat(sqlQuery, ";", PRAGMATimeOut, ";", "PRAGMA journal_mode=WAL"), sqlConnect))
                    {
                        //sqlCmd.ExecuteNonQuery();                       
                        using (SQLiteDataReader reader = sqlCmd.ExecuteReader())
                        {
                            // Load the data from the reader into the DataTable
                            datatable.Load(reader);
                        }
                        return datatable;
                    }

                }
                catch (Exception ex)
                {
                    _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "FetchAllDetails", "WFALog", "SqlLite", ex.Message, null, null);

                    throw;
                }
                finally
                {
                    /* transaction.Rollback();*/
                    sqlConnect.Close();
                    //sqlConnect.Dispose();
                }
                /*  }*/

            }

        }
        public async Task<LocationModel> FetchLocationDetailsById(int locationId)
        {
            try
            {
                _logger.Information("resquest returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Request", "FetchLocationDetailsById", "WFALog", "SqlLite", null, null, null);
                var fetchLocationDetails = await FetchDetailsByLocationId(locationId);
                LocationModel locationModel = new LocationModel();
                LocationParam locationparam = new LocationParam();
                foreach (DataRow row in fetchLocationDetails.Rows)
                {
                    locationparam.Address = row["Address"].ToString();
                    locationparam.CustomerId = Convert.ToInt32(row["CustomerId"]);
                    locationparam.LocationId = Convert.ToInt32(row["LocationId"]);
                }
                locationModel.LocationDetail = locationparam;
                _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Response", "FetchLocationDetailsById", "WFALog", "SqlLite", "Suucess", null, JsonConvert.SerializeObject(locationparam));
                return locationModel;
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Error", "FetchLocationDetailsById", "WFALog", "SqlLite", ex.Message, null, null);
                return new LocationModel
                {
                    Code = "101",
                    Message = ex.Message,
                };
            }
        }
        public async Task<LocationModel> FetchLocationAllDetails()
        {
            try
            {
                _logger.Information("resquest returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "FetchLocationAllDetails", "WFALog", "SqlLite", null, null, null);
                var fetchLocationDetails = await FetchLocationAllDetail();
                LocationModel locationModel = new LocationModel();
                List<LocationParam> locationList = new List<LocationParam>();
                foreach (DataRow row in fetchLocationDetails.Rows)
                {
                    LocationParam locationparam = new LocationParam();
                    locationparam.Address = row["Address"].ToString();
                    locationparam.CustomerId = Convert.ToInt32(row["CustomerId"]);
                    locationparam.LocationId = Convert.ToInt32(row["LocationId"]);
                    locationparam.CreatedDate = row["CreatedDate"].ToString();
                    locationparam.UpdateDate = row["UpdateDate"].ToString();
                    locationList.Add(locationparam);
                }
                locationModel.LocationList = locationList;
                _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Response", "FetchLocationAllDetails", "WFALog", "SqlLite", "Suucess", null, JsonConvert.SerializeObject(locationList));
                return locationModel;
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "FetchLocationAllDetails", "WFALog", "SqlLite", ex.Message, null, null);
                return new LocationModel
                {
                    Code = "101",
                    Message = ex.Message,
                };
            }
        }
        #endregion Location
    }
}
