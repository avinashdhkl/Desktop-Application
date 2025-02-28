using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Drapper
{
    public interface IDapper
    {
        Task<List<T0>> ExecuteQueryAsync<T0>(string sqlQuery,object sqlParam,CommandType commandType= CommandType.StoredProcedure);
    }
}
