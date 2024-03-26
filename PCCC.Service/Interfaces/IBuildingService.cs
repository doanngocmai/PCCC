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

        Task<JsonResultModel> CreateContent(CreateBuildingModel model);
        Task<JsonResultModel> UpdateContent(UpdateBuildingModel model);
        Task<JsonResultModel> DeleteContent(int ID);
        Task<JsonResultModel> GetListContent(BuildingSearchPageResults param);
    }
}
