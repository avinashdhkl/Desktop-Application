using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsCommon.ApiServices
{
    public class ApiServices : IApiServices
    {
        private readonly ILogger _logger= Log.ForContext<ApiServices>();
        public async Task<string> WebApi(string endPoints, object param=null, string method = "GET")
        {
			try
			{
                string baseUrl = ConfigurationManager.AppSettings["BaseUrl"];               
                string url = String.Concat(baseUrl, endPoints);
                using (HttpClient client = new HttpClient()) {
                    _logger.Information("Request returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Request", "WebApi", "APILOG", "API", null, url, null);
                    HttpResponseMessage responseMessage = await client.GetAsync(url);
                    _logger.Information("Response returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Response", "WebApi", "APILOG", "API", responseMessage.RequestMessage.ToString(), url, JsonConvert.SerializeObject(responseMessage));
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var resp = await responseMessage.Content.ReadAsStringAsync();   
                        return resp;
                    }
                    return "Error";
                }

            }
            catch (Exception ex)
			{
                _logger.Error("Error returned as {UnqiueNo}{Method}{Action}{LogType}{DB}{Messages}{Param}{Response}", null, "Error", "WebApi", "APILOG", "API",ex.Message, null, null);
                throw;
			}
        }
    }
}
