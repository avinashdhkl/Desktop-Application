using DataAccessSqlLite.SqlLite;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WinFormsBusiness.Model.Location;
using WinFormsCommon.Model.Common;


namespace WinFormsBusiness.Services.Location
{
    public class LocationService:ILocationService
    {
        private const string errorCode = "101";
        private const string successCode = "200";
        private readonly ILogger _logger = Log.ForContext<LocationService>();
        private readonly ISqlLiteDataAccess  _sqlLiteDataAccess;
        public LocationService(ISqlLiteDataAccess sqlLiteDataAccess)
        {
                _sqlLiteDataAccess = sqlLiteDataAccess;
        }
        #region DB Connection
        private string GetConnectionString()
        {

            string connectionStrings = ConfigurationManager.ConnectionStrings["connectionstring"]?.ConnectionString;
            return connectionStrings;
        }
        private async Task<DataTable> FetchDataTable(string sqlQuery = "select * from Location.TBL_LocationDetail")
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
        private async Task<DataTable> FetchDataTableById(int LocationId, string sqlQuery = "select * from Location.TBL_LocationDetail where LocationId =@LocationId")
        {
            SqlConnection sqlConn = new SqlConnection(GetConnectionString());
            DataTable table = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                cmd.Parameters.AddWithValue("@LocationId", LocationId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                await sqlConn.OpenAsync();
                adapter.Fill(table);
                return table;
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", LocationId.ToString(), "Error", "FetchDataTableById", "WFALog", "MSSQlServer", ex.Message, LocationId.ToString(), null);
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        private async Task<bool> InsertDataTable(LocationParam locationparam, string sqlQuery = "Insert Into Location.TBL_LocationDetail(Address,CustomerId,CreatedDate) Values(@Address,@CustomerId,@CreatedDate)")
        {
            bool isSuccess = false;
            SqlConnection sqlConn = new SqlConnection(GetConnectionString());
            //DataTable table = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                cmd.Parameters.AddWithValue("@Address", locationparam.Address.Trim());
                cmd.Parameters.AddWithValue("@CustomerId", locationparam.CustomerId);                
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
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}",null, "Error", "InsertDataTable", "WFALog", "MSSQlServer", ex.Message, JsonConvert.SerializeObject(locationparam), null);
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        private async Task<bool> UpdateDataTable(LocationParam locationparam, string sqlQuery = "update Location.TBL_LocationDetail set Address=@Address,CustomerId=@CustomerId,UpdateDate=@UpdateDate where LocationId=@LocationId")
        {
            bool isSuccess = false;
            SqlConnection sqlConn = new SqlConnection(GetConnectionString());
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                cmd.Parameters.AddWithValue("@Address", locationparam.Address);
                cmd.Parameters.AddWithValue("@CustomerId", locationparam.CustomerId);                
                cmd.Parameters.AddWithValue("@UpdateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@LocationId", locationparam.LocationId);
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
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationparam.LocationId.ToString(), "Error", "UpdateDataTable", "WFALog", "MSSQlServer", ex.Message, JsonConvert.SerializeObject(locationparam), null);
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }
        private async Task<bool> DeleteDataTable(int LocationId, string sqlQuery = "Delete From Location.TBL_LocationDetail where LocationId=@LocationId")
        {
            bool issuccess = false;
            SqlConnection sqlConn = new SqlConnection(GetConnectionString());
            try
            {
                SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn);
                cmd.Parameters.AddWithValue("@LocationId", LocationId);
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
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", LocationId.ToString(), "Error", "DeleteDataTable", "WFALog", "MSSQlServer", ex.Message, LocationId.ToString(), null);
                throw;
            }
            finally { sqlConn.Close(); }
        }
        #endregion   DB Connection
        #region Location
        public async Task<CommonModel> InsertLocation(LocationParam locationparam)
        {
            try
            {
                _logger.Information("request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "InsertLocation", "WFALog", "MSSQlServer",null, JsonConvert.SerializeObject(locationparam), null);
                var resp = await InsertDataTable(locationparam);
                if (resp)
                {
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Response", "InsertLocation", "WFALog", "MSSQlServer", "Success", JsonConvert.SerializeObject(locationparam), resp);
                    return new CommonModel
                    {
                        Code = successCode,
                        Message = "Insert Successfull",
                    };
                }
                _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Response", "InsertLocation", "WFALog", "MSSQlServer", "Insert Process is Incomplete", JsonConvert.SerializeObject(locationparam), resp);
                return new CommonModel
                {
                    Code = errorCode,
                    Message = "Insert Process is Incomplete",
                };
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "InsertLocation", "WFALog", "MSSQlServer", ex.Message, JsonConvert.SerializeObject(locationparam), null);
                return new CommonModel
                {
                    Code = "101",
                    Message = ex.Message,
                };


            }
        }
        public async Task<CommonModel> UpdateLocation(LocationParam locationparam)
        {
            try
            {
                _logger.Information("request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationparam.LocationId.ToString(), "Request", "UpdateLocation", "WFALog", "MSSQlServer", null, JsonConvert.SerializeObject(locationparam), null);
                var resp = await UpdateDataTable(locationparam);
                if (resp)
                {
                    await _sqlLiteDataAccess.UpdateLocationDataTable(locationparam);
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationparam.LocationId.ToString(), "Response", "UpdateLocation", "WFALog", "MSSQlServer", "Update Process is Success", JsonConvert.SerializeObject(locationparam), resp);
                    return new CommonModel
                    {
                        Code = successCode,
                        Message = "Update Successfull",
                    };
                }
                _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationparam.LocationId.ToString(), "Response", "UpdateLocation", "WFALog", "MSSQlServer", "Update Process is Incomplete", JsonConvert.SerializeObject(locationparam), resp);
                return new CommonModel
                {
                    Code = errorCode,
                    Message = "Update Process is Incomplete",
                };
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationparam.LocationId.ToString(), "Error", "UpdateLocation", "WFALog", "MSSQlServer", ex.Message, JsonConvert.SerializeObject(locationparam), null);
                return new CommonModel
                {
                    Code = "101",
                    Message = ex.Message,
                };


            }
        }
        public async Task<LocationModel> FetchAllLocationDetails()
        {
            try
            {
                _logger.Information("request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "FetchAllLocationDetails", "WFALog", "MSSQlServer", null, null, null);
                LocationModel locationmodel = new LocationModel();
                var resp = await FetchDataTable();
                List<LocationParam> LocationList = new List<LocationParam>();
                foreach (DataRow row in resp.Rows)
                {
                    LocationParam locationparam = new LocationParam();
                    locationparam.Address = row["Address"].ToString();
                    locationparam.CustomerId = Convert.ToInt32(row["CustomerId"]);
                    locationparam.LocationId = Convert.ToInt32(row["LocationId"]);
                    locationparam.CreatedDate = row["CreatedDate"].ToString();
                    locationparam.UpdateDate = row["UpdateDate"].ToString();
                    LocationList.Add(locationparam);
                }
                locationmodel.LocationList = LocationList;
                _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Response", "FetchAllLocationDetails", "WFALog", "MSSQlServer", null, null, JsonConvert.SerializeObject(LocationList));
                return locationmodel;
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "FetchAllLocationDetails", "WFALog", "MSSQlServer", null, null, null);
                return new LocationModel
                {
                    Code = errorCode,
                    Message = ex.Message,
                };
            }
        }
        public async Task<LocationModel> FetchLocationDetailsById(int locationId)
        {
            try
            {
                _logger.Information("request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Request", "FetchLocationDetailsById", "WFALog", "MSSQlServer", null, JsonConvert.SerializeObject(locationId.ToString()), null);
                LocationModel locationmodel = new LocationModel();
                var resp = await FetchDataTableById(locationId);
                LocationParam locationparam = new LocationParam();
                foreach (DataRow row in resp.Rows)
                {
                    locationparam.Address = row["Address"].ToString();                                       
                    locationparam.CustomerId = Convert.ToInt32(row["CustomerId"]);
                    locationparam.LocationId = Convert.ToInt32(row["LocationId"]);
                }
                locationmodel.LocationDetail = locationparam;
                _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Response", "FetchLocationDetailsById", "WFALog", "MSSQlServer", "Success", JsonConvert.SerializeObject(locationId.ToString()), JsonConvert.SerializeObject(locationparam));
                return locationmodel;
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Error", "FetchLocationDetailsById", "WFALog", "MSSQlServer", ex.Message, JsonConvert.SerializeObject(locationId.ToString()), null);
                return new LocationModel
                {
                    Code = errorCode,
                    Message = ex.Message,
                };
            }
        }
        public async Task<CommonModel> DeleteLocation(int locationId)
        {
            try
            {
                _logger.Information("request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Request", "DeleteLocation", "WFALog", "MSSQlServer", null, JsonConvert.SerializeObject(locationId.ToString()), null);
                var resp = await DeleteDataTable(locationId);
                if (resp)
                {
                    await _sqlLiteDataAccess.DeleteLocationDataTable(locationId);
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Response", "DeleteLocation", "WFALog", "MSSQlServer", "Delete process incomplete", JsonConvert.SerializeObject(locationId.ToString()), resp);
                    return new CommonModel
                    {
                        Code = successCode,
                        Message = "Delete Successful",
                    };
                }
                _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Response", "DeleteLocation", "WFALog", "MSSQlServer", "Delete process incomplete", JsonConvert.SerializeObject(locationId.ToString()), resp);
                return new CommonModel
                {

                    Code = errorCode,
                    Message = "Delete process incomplete",
                };
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", locationId.ToString(), "Error", "DeleteLocation", "WFALog", "MSSQlServer", ex.Message, JsonConvert.SerializeObject(locationId.ToString()), null);
                return new CommonModel
                {
                    Code = errorCode,
                    Message = ex.Message,
                };
            }
        }
        public async void synch_InsertLocation()
        {
            try
            {
                _logger.Information("request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "synch_InsertCustomer", "WFALog", "sqlLite", null, null, null);
                var fetchAllDetails = await FetchAllLocationDetails();
                foreach (var item in fetchAllDetails.LocationList) {
                    var fetchdetailById = await _sqlLiteDataAccess.FetchLocationDetailsById(item.LocationId);
                    if (fetchdetailById.LocationDetail.LocationId<=0)
                    {
                        await _sqlLiteDataAccess.InsertLocationDataTable(item);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "synch_InsertCustomer", "WFALog", "sqlLite", ex.Message, null, null);
                
            }
        }
        #endregion Location
    }
}
