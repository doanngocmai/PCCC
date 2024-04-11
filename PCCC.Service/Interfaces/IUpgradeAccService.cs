using PCCC.Common.Utils;
using PCCC.Common.DTOs.Roles;
using PCCC.Data.Entities;
using PCCC.Service.Interfaces;
using PCCC.Common.DTOs.UpgradeAccs;

namespace PCCC.Service.Services
{
    public interface IUpgradeAccService : IServices<UpgradeAccount>
    {
        Task<JsonResultModel> CreateUpgradeAcc(CreateUpgradeAccModel model);
        Task<JsonResultModel> UpdateUpgradeAcc(UpdateUpgradeAccModel model);
        Task<JsonResultModel> DeleteUpgradeAcc(int ID);
        Task<JsonResultModel> GetListUpgradeAccount(UpgradeAccSearchPageResult param);
    }
}
