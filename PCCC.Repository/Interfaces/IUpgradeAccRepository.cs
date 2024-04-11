using PagedList.Core;
using PCCC.Common.DTOs.UpgradeAccs;
using PCCC.Data.Entities;

namespace PCCC.Repository.Interfaces
{
    public interface IUpgradeAccRepository : IRepository<UpgradeAccount>
    {
        Task<IPagedList<UpgradeAccModel>> GetUpgrateAccs(UpgradeAccSearchPageResult param);
    }
}
