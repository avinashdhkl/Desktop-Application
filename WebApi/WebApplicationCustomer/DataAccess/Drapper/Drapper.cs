using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Drapper
{
    public class Drapper: IDapper
    {
        private readonly IConfiguration _configuration;      
        public Drapper(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        private string GetConnectionString()
        {
            string connnectionstring = _configuration.GetConnectionString("DefaultConnection");
            return connnectionstring;
        }
        public async Task<List<T0>> ExecuteQueryAsync<T0>(string sqlQuery, object sqlParam, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var sqlConn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    sqlConn.Open();
                    using (var result = await sqlConn.QueryMultipleAsync(sqlQuery, sqlParam, commandTimeout: 3000, commandType: commandType))
                    {
                        var res = result.Read<T0>().ToList();
                        return res;
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
                finally
                {
                    sqlConn.Close();
                }
               
            }
        }

        
    }
}
