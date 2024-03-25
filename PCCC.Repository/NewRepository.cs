using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using PCCC.Common.DTOs.News;
using PCCC.Common.Utils;
using PCCC.Data;
using PCCC.Data.Entities;
using PCCC.Repository;
using PCCC.Repository.Interfaces;

namespace PCCC.Repository
{
    public class NewRepository : BaseRepository<News>, INewRepository
    {
        public NewRepository(PcccContext dbContext) : base(dbContext)
        {

        }

        public async Task<IPagedList<NewModel>> GetNews(NewSearchPageResults param)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var fd = Util.ConvertFromDate(param.fromDate);
                    var td = Util.ConvertToDate(param.toDate);
                var model = (from u in DbContext.News
                             where (!string.IsNullOrEmpty(param.SearchKey) ? u.Title.Contains(param.SearchKey) : true && param.IsActive.HasValue ? u.IsActive == param.IsActive : true)
                                 select new NewModel
                                 {
                                     Id = u.Id,
                                     Type = u.Type,
                                     Content = u.Content,
                                     Title = u.Title,
                                     IsActive = u.IsActive,
                                     Image = u.Image,
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
