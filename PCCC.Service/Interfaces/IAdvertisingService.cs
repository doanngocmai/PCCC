using PCCC.Common.DTOs.Ads;
using PCCC.Common.Utils;
using PCCC.Data.Entities;

namespace PCCC.Service.Interfaces
{
    public interface IAdvertisingService : IServices<Advertisement>
    {

        Task<JsonResultModel> CreateAds(CreateAdsModel model);
        Task<JsonResultModel> UpdateAds(UpdateAdsModel model);
        Task<JsonResultModel> DeleteAds(int ID);
        Task<JsonResultModel> GetListAds(AdsSearchPageResults param);
    }
}
