using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsCommon.ApiServices
{
    public interface IApiServices
    {
        Task<string> WebApi(string endPoints, object param=null,string method="GET");

    }
}
