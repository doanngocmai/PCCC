using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PCCC.Common.DTOs.Contents;
using PCCC.Common.Utils;
using PCCC.Data;
using PCCC.Data.Entities;
using PCCC.Repository;
using PCCC.Repository.Interfaces;

namespace PCCC.Repository
{
    public class ContentRepository : BaseRepository<Content>, IContentRepository
    {
        public ContentRepository(PcccContext dbContext) : base(dbContext)
        {

        }

        public async Task<IPagedList<ContentModel>> GetContents(int page, int limit, string SearchKey, int? status, string fromDate, string toDate)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var fd = Util.ConvertFromDate(fromDate);
                    var td = Util.ConvertToDate(toDate);
                var model = (from u in DbContext.Contents
                             where (!string.IsNullOrEmpty(SearchKey) ? u.Name.Contains(SearchKey) : true && status.HasValue ? u.IsActive.Equals(status) : true)
                                 select new ContentModel
                                 {
                                     Id = u.Id,
                                     Name = u.Name,
                                     Type = u.Type,
                                     Link = u.Link,
                                     Color = u.Color,
                                     Description = u.Description,
                                     Icon = u.Icon,
                                     IsActive = u.IsActive,
                                     CreationTime = u.CreationTime,
                                 }).AsQueryable().ToPagedList(page, limit);
                    return model;
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
