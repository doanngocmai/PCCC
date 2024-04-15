using PagedList.Core;
using PCCC.Common.DTOs.Ads;
using PCCC.Common.DTOs.ApartmentUsers;
using PCCC.Common.Utils;
using PCCC.Data.Entities;

namespace PCCC.Repository.Interfaces
{
    public interface IApartmentUserRepository : IRepository<ApartmentUser>
    {
        Task<IPagedList<ApartmentUserModel>> GetApartmentUsers(ApartmentUserSearchPageResults param);
    }
}
