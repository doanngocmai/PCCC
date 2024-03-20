﻿using PagedList.Core;
using PCCC.Common.DTOs.Contents;
using PCCC.Common.DTOs.Roles;
using PCCC.Data.Entities;

namespace PCCC.Repository.Interfaces
{
    public interface IContentRepository : IRepository<Content>
    {
        Task<IPagedList<ContentModel>> GetContents(ContentSearchPageResults param);
    }
}
