﻿using Microsoft.EntityFrameworkCore.Query;
using PCCC.Common.DTOs.Contents;
using PCCC.Common.DTOs.Roles;
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
    public interface IContentService : IServices<Content>
    {

        Task<JsonResultModel> CreateContent(CreateContentModel model);
        Task<JsonResultModel> UpdateContent(UpdateContentModel model);
        Task<JsonResultModel> DeleteContent(int ID);
        Task<JsonResultModel> GetListContent(ContentSearchPageResults param);
    }
}
