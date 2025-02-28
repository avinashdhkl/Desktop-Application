using Azure;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsBusiness.Model.Location;
using WinFormsCommon.ApiServices;
using WinFormsCommon.Model.Dashoard;

namespace WinFormsBusiness.Services.Dashoard
{
    public class DashoardServices: IDashboardServices
    {
        private readonly IApiServices _apiServices;
        private readonly ILogger _logger= Log.ForContext<DashoardServices>();
        private const string errorCode = "101";
        private const string successCode = "200";
        public DashoardServices(IApiServices apiServices)
        {
                this._apiServices = apiServices;
        }

        public async Task<CustomerModel> FetchCustomer()
        {
            try
            {
                string endPoints = "/api/Customers";
                _logger.Information("Request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "FetchCustomer", "APILOG", "API", null, endPoints, null);
                var resp = await _apiServices.WebApi(endPoints);
                if (resp.ToLower()!="error")
                {
                   
                    var response = JsonConvert.DeserializeObject<CustomerModel>(resp);
                    _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Response", "FetchCustomer", "APILOG", "API", response.Message, endPoints, JsonConvert.SerializeObject(response));
                    return response;
                }
                _logger.Information("response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Response", "FetchCustomer", "APILOG", "API", "Api Error", endPoints, null);
                return new CustomerModel
                {
                    Code = errorCode,
                    Message = "Api Error",
                };
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "FetchCustomerLocation", "APILOG", "API", ex.Message, null, null);
                return new CustomerModel
                {
                    Code = errorCode,
                    Message = ex.Message,
                };
            }
        }
        public async Task<CustomerLocationModel> FetchCustomerLocation(int customerId)
        {
            try
            {
                string endPoints = string.Concat("/api/Customers/", customerId, "/locations");
                _logger.Information("Request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Request", "FetchCustomerLocation", "APILOG", "API", null, customerId.ToString(), null);
                var resp = await _apiServices.WebApi(endPoints);
                if (resp.ToLower() != "error")
                {
                    var response = JsonConvert.DeserializeObject<CustomerLocationModel>(resp);
                    _logger.Information("Response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Response", "FetchCustomerLocation", "APILOG", "API", response.Message, customerId.ToString(), JsonConvert.SerializeObject(response));
                    return response;
                }
                _logger.Information("Response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Response", "FetchCustomerLocation", "APILOG", "API", resp, customerId.ToString(), JsonConvert.SerializeObject(resp));
                return new CustomerLocationModel
                {
                    Code = errorCode,
                    Message = "Api Error",
                };
            }
            catch (Exception ex)
            {
                _logger.Error("error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", customerId.ToString(), "Error", "FetchCustomerLocation", "APILOG", "API", ex.Message, customerId.ToString(), null);
                return new CustomerLocationModel
                {
                    Code = errorCode,
                    Message = ex.Message,
                };
            }
        }
    }
}
