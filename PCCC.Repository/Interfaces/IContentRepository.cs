using PagedList.Core;
using PCCC.Common.DTOs.Contents;
using PCCC.Common.DTOs.Roles;
using PCCC.Data.Entities;

namespace PCCC.Repository.Interfaces
{
    public interface IContentRepository : IRepository<Content>
    {
       Task<IPagedList<ContentModel>> GetContents(int page, int limit, string SearchKey, int? status, string fromDate, string toDate);
    }
}
