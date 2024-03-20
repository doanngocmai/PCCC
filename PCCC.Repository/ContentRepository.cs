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

        public async Task<IPagedList<ContentModel>> GetContents(ContentSearchPageResults param)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var fd = Util.ConvertFromDate(param.fromDate);
                    var td = Util.ConvertToDate(param.toDate);
                var model = (from u in DbContext.Contents
                             where (!string.IsNullOrEmpty(param.SearchKey) ? u.Name.Contains(param.SearchKey) : true && param.IsActive.HasValue ? u.IsActive == param.IsActive : true)
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
                                 }).AsQueryable().ToPagedList(param.page, param.perPage);
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
