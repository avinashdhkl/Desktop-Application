using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsBusiness.Model.Location;
using WinFormsCommon.Model.Common;

namespace WinFormsBusiness.Services.Location
{
    public interface ILocationService
    {
        Task<CommonModel> InsertLocation(LocationParam locationparam);
        Task<CommonModel> UpdateLocation(LocationParam locationparam);
        Task<LocationModel> FetchAllLocationDetails();
        Task<LocationModel> FetchLocationDetailsById(int locationId);
        Task<CommonModel> DeleteLocation(int locationId);
        void synch_InsertLocation();
    }
}
