using DataAccess.Drapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Generic
{
    public class Generic:IGeneric
    {
        private readonly IDapper _dapper;
        public Generic(IDapper dapper)
        {
            _dapper = dapper;
        }

        public async Task<List<T>> ManageWithList<T>(string storeProcedure, object sqlParam)
        {
            var resp = await _dapper.ExecuteQueryAsync<T>(storeProcedure, sqlParam);
            return resp;
        }

        public async Task<T> ManageWithObject<T>(string storeProcedure, object sqlParam)
        {
            var resp = await _dapper.ExecuteQueryAsync<T>(storeProcedure,sqlParam);
            return resp.FirstOrDefault();
        }
    }
}
