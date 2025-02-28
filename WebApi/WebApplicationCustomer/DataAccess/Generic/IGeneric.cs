using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Generic
{
    public interface IGeneric
    {
        Task<T> ManageWithObject<T>(string storeProcedure,object sqlParam);
        Task<List<T>> ManageWithList<T>(string storeProcedure,object sqlParam);
    }
}
