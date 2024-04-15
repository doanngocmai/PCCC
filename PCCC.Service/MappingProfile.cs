using AutoMapper;
using PCCC.Common.DTOs.Buildings;
using PCCC.Common.DTOs.Contents;
using PCCC.Common.DTOs.News;
using PCCC.Common.DTOs.Roles;
using PCCC.Common.DTOs.UpgradeAccs;
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
            CreateMap<User, CreateUserModel>();
            CreateMap<Role, CreateRoleModel>();
            CreateMap<Role, UpdateRoleModel>();
            CreateMap<Content, CreateContentModel>();
            CreateMap<Content, UpdateContentModel>();
            CreateMap<News, CreateNewModel>();
            CreateMap<News, UpdateNewModel>();            
            CreateMap<Building, BuildingModel>();
            CreateMap<Building, CreateBuildingModel>();
            CreateMap<Building, UpdateBuildingModel>();  
            CreateMap<UpgradeAccount, CreateUpgradeAccModel>();
            CreateMap<UpgradeAccount, UpdateUpgradeAccModel>();
        }

        private void MappingViewModelToEntity()
        {
            // case insert or update
            CreateMap<UserModel, User>();
            CreateMap<CreateUserModel, User>();
            CreateMap<UpdateUserModel, User>();
            CreateMap<CreateRoleModel, Role>();
            CreateMap<UpdateRoleModel, Role>();
            CreateMap<CreateContentModel, Content>();
            CreateMap<UpdateContentModel, Content>();
            CreateMap<CreateNewModel, News>();
            CreateMap<UpdateNewModel, News>();           
            CreateMap<BuildingModel, Building>();
            CreateMap<CreateBuildingModel, Building>();
            CreateMap<UpdateBuildingModel, Building >(); 
            CreateMap<CreateUpgradeAccModel, UpgradeAccount>();
            CreateMap<UpdateUpgradeAccModel, UpgradeAccount>();
        }
    }
}
