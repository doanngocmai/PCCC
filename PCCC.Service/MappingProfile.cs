using AutoMapper;
using PCCC.Common.DTOs.Users;
using PCCC.Data.Entities;

namespace PCCC.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MappingEntityToViewModel();
            MappingViewModelToEntity();
        }
        private void MappingEntityToViewModel()
        {
            CreateMap<User, UserModel>();
        }

        private void MappingViewModelToEntity()
        {
            // case insert or update
            CreateMap<UserModel, User>();
        }
    }
}
