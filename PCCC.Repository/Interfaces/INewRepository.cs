using PagedList.Core;
using PCCC.Common.DTOs.News;
using PCCC.Data.Entities;

namespace PCCC.Repository.Interfaces
{
    public interface INewRepository : IRepository<News>
    {
        Task<IPagedList<NewModel>> GetNews(NewSearchPageResults param);
    }
}
