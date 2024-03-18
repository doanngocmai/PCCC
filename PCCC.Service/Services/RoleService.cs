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
        public async Task<JsonResultModel> CreateRole(CreateRoleModel model)
        {   
            try
            {
                var roleName = await _roleRepository.GetFirstOrDefaultAsync(x => x.RoleName == model.RoleName);
                if (roleName != null)
                    return JsonResponse.Error(PCCCConsts.ERROR_ROLE_NAME_ALREADY_EXIST, PCCCConsts.MESSAGE_ROLE_NAME_ALREADY_EXIST);
                Role role = new Role()
                {
                    RoleName = model.RoleName,
                    DisplayName = model.DisplayName,
                    Note = model.Note,
                    CreationTime = DateTime.Now,
                    IsActive = model.IsActive
                };
                await _roleRepository.AddAsync(role);
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
                var role = await _roleRepository.GetFirstOrDefaultAsync(x => x.Id == ID && !x.IsActive);
                if (role == null) return JsonResponse.Error(PCCCConsts.ERROR_ROLE_NOT_FOUND, PCCCConsts.MESSAGE_ROLE_NOT_FOUND);
                role.IsActive = true;
                await _roleRepository.UpdateAsync(role);
                return JsonResponse.Success();
            }
            catch (Exception Ex)
            {
                return JsonResponse.ServerError();

            }
        }

        public async Task<JsonResultModel> GetListRole(int page, int limit, string SearchKey, int? status, string fromDate, string toDate)
        {
            try
            {
                var list = await _roleRepository.GetRoles(page, limit, SearchKey, status, fromDate, toDate);
                DataPagedListModel dataPagedListModel = new DataPagedListModel()
                {
                    Data = list,
                    Limit = limit,
                    Page = page,
                    TotalItemCount = list.TotalItemCount
                };
                return JsonResponse.Success(dataPagedListModel);
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
                // lấy bản ghi trong cơ sở dữ liệu
                var record = await _roleRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(model.Id));
                if (record == null) return JsonResponse.Error(PCCCConsts.ERROR_ROLE_NOT_FOUND, PCCCConsts.MESSAGE_ROLE_NOT_FOUND);
                // Gán các giá trị cho bản ghi
                record.DisplayName = model.DisplayName;
                record.Note = model.Note;
                record.IsActive = model.IsActive;
                var res = await _roleRepository.UpdateAsync(record);
                // cập nhật thành công 
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
    }
}
