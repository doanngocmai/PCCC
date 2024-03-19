using AutoMapper;
using PCCC.Common.Utils;
using PCCC.Service.Services;
using PCCC.Common.DTOs.Roles;
using PCCC.Data.Entities;
using PCCC.Common.DTOs;
using PCCC.Repository.Interfaces;

namespace PCCCC.Service.Services
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository roleRepository, IMapper mapper) : base(roleRepository)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public async Task<JsonResultModel> GetListRole(RoleSearchPageResults param)
        {
            try
            {
                var list = await _roleRepository.GetRoles(param);
                DataPagedListModel dataPagedListModel = new DataPagedListModel()
                {
                    Data = list,
                    Limit = param.perPage,
                    Page = param.page,
                    TotalItemCount = list.TotalItemCount
                };
                return JsonResponse.Success(dataPagedListModel);
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> CreateRole(CreateRoleModel model)
        {   
            try
            {
                var roleName = await _roleRepository.GetFirstOrDefaultAsync(x => x.RoleName == model.RoleName);
                if (roleName != null)
                    return JsonResponse.Error(PCCCConsts.ERROR_ROLE_NAME_ALREADY_EXIST, PCCCConsts.MESSAGE_ROLE_NAME_ALREADY_EXIST);
                var role = _mapper.Map<Role>(model);
                role.CreationTime = DateTime.Now;
                await _roleRepository.AddAsync(role);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> UpdateRole(UpdateRoleModel model)
        {
            try
            {
                var record = await _roleRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(model.Id));
                if (record == null) return JsonResponse.Error(PCCCConsts.ERROR_ROLE_NOT_FOUND, PCCCConsts.MESSAGE_ROLE_NOT_FOUND);
                _mapper.Map(model, record);
                await _roleRepository.UpdateAsync(record);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> DeleteRole(int ID)
        {
            try
            {
                var role = await _roleRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(ID));
                if (role == null) return JsonResponse.Error(PCCCConsts.ERROR_ROLE_NOT_FOUND, PCCCConsts.MESSAGE_ROLE_NOT_FOUND);
                //Xóa cứng
                await _roleRepository.DeleteAsync(role);
                return JsonResponse.Success();
            }
            catch (Exception Ex)
            {
                return JsonResponse.ServerError();

            }
        }

       
       
    }
}
