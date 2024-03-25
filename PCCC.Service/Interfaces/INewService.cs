using Microsoft.EntityFrameworkCore.Query;
using PCCC.Common.DTOs.News;
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
    public interface INewService : IServices<News>
    {

        Task<JsonResultModel> CreateNew(CreateNewModel model);
        Task<JsonResultModel> UpdateNew(UpdateNewModel model);
        Task<JsonResultModel> DeleteNew(int ID);
        Task<JsonResultModel> GetListNew(NewSearchPageResults param);
    }
}
