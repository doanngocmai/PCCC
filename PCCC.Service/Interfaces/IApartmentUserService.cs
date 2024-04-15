using PCCC.Common.DTOs.ApartmentUsers;
using PCCC.Common.Utils;
using PCCC.Data.Entities;

namespace PCCC.Service.Interfaces
{
    public interface IApartmentUserService : IServices<ApartmentUser>
    {

        Task<JsonResultModel> CreateApartmentUser(CreateApartmentUserModel model);
        Task<JsonResultModel> UpdateApartmentUser(UpdateApartmentUserModel model);
        Task<JsonResultModel> DeleteApartmentUser(int ID);
        Task<JsonResultModel> GetListApartmentUser(ApartmentUserSearchPageResults param);
    }
}
