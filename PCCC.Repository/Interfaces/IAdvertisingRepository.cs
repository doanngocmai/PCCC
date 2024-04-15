using PagedList.Core;
using PCCC.Common.DTOs.Ads;
using PCCC.Common.DTOs.Contents;
using PCCC.Data.Entities;

namespace PCCC.Repository.Interfaces
{
    public interface IAdvertisingRepository : IRepository<Advertisement>
    {
        Task<IPagedList<AdsModel>> GetAds(AdsSearchPageResults param);
    }
}
