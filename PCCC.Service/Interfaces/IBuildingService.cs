using Microsoft.EntityFrameworkCore.Query;
using PCCC.Common.DTOs.Buildings;
using PCCC.Common.Utils;
using PCCC.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Service.Interfaces
{
    public interface IBuildingService : IServices<Building>
    {

        Task<JsonResultModel> CreateBuilding(CreateBuildingModel model);
        Task<JsonResultModel> UpdateBuilding(UpdateBuildingModel model);
        Task<JsonResultModel> DeleteBuilding(int ID);
        Task<JsonResultModel> GetBuildingById(int ID);
        Task<JsonResultModel> GetListBuilding(BuildingSearchPageResults param);
        Task<JsonResultModel> GetListAllBuilding();
    }
}
