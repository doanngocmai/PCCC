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
        //public async Task<JsonResultModel> DeleteRole(int ID)
        //{
        //    try
        //    {
        //        var user = await _roleRepository.GetFirstOrDefaultAsync(x => x.Id == ID && x.IsActive == PCCCConsts.ACTIVE);
        //        if (user == null) return JsonResponse.Error(PCCCConsts.ERROR_USER_NOT_FOUND, PCCCConsts.MESSAGE_USER_NOT_FOUND);
        //        user.IsActive = PCCCConsts.ACTIVE_FALSE;
        //        await _roleRepository.UpdateAsync(user);
        //        return JsonResponse.Success();
        //    }
        //    catch (Exception Ex)
        //    {
        //        return JsonResponse.ServerError();

        //    }
        //}
        //public async Task<JsonResultModel> GetRoleDetail(int ID)
        //{
        //    try
        //    {
        //        // Kiểm tra User có tồn tại hay khôngs
        //        var user = await _roleRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(ID) && x.IsActive.Equals(PCCCConsts.ACTIVE));
        //        if (user == null) return JsonResponse.Error(PCCCConsts.ERROR_USER_NOT_FOUND, PCCCConsts.MESSAGE_USER_NOT_FOUND);

        //        // Nếu Trường hợp có tồn tại
        //        UserDetailModel _user = new UserDetailModel()
        //        {
        //            ID = user.Id,
        //            Name = user.UserName,
        //            Phone = user.Phone,
        //            Email = user.Email,
        //            Address = user.Address,
        //            Status = user.IsActive,
        //        };
        //        // Trả ra người dùng :
        //        return JsonResponse.Success(user);
        //    }
        //    catch (Exception ex)
        //    {
        //        return JsonResponse.ServerError();
        //    }
        //}

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
        //public async Task<JsonResultModel> UpdateUser(UpdateUserModel model)
        //{
        //    try
        //    {
        //        // lấy bản ghi trong cơ sở dữ liệu
        //        var record = await _roleRepository.GetFirstOrDefaultAsync(x => x.IsActive.Equals(PCCCConsts.ACTIVE) && x.Id.Equals(model.ID));
        //        if (record == null) return JsonResponse.Error(PCCCConsts.ERROR_USER_NOT_FOUND, PCCCConsts.MESSAGE_USER_NOT_FOUND);
        //        if (!Util.validPhone(model.Phone))
        //            return JsonResponse.Error(PCCCConsts.ERROR_REGISTER_PHONE_INVALID, PCCCConsts.MESSAGE_REGISTER_PHONE_INVALID);
        //        // Gán các giá trị cho bản ghi
        //        record.UserName = model.Name;
        //        record.Phone = model.Phone;
        //        record.Email = model.Email;
        //        record.IsActive = model.Status;
        //        var res = await _roleRepository.UpdateAsync(record);
        //        // cập nhật thành công 
        //        return JsonResponse.Success();
        //    }
        //    catch (Exception ex)
        //    {
        //        return JsonResponse.ServerError();
        //    }
        //}

        //public async Task<JsonResultModel> UpdateDetailUser(int id, UpdateUserModelNew input)
        //{
        //    try
        //    {
        //        if (String.IsNullOrEmpty(input.Email) || String.IsNullOrEmpty(input.Address))
        //            return JsonResponse.Error(PCCCConsts.ERROR_REGISTER_FIELDS_INVALID, PCCCConsts.MESSAGE_REGISTER_FIELDS_INVALID);
        //        if (!Util.ValidateEmail(input.Email))
        //            return JsonResponse.Error(PCCCConsts.ERROR_REGISTER_EMAIL_INVALID, PCCCConsts.MESSAGE_REGISTER_EMAIL_INVALID);
        //        var model = await _roleRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(id));
        //        _mapper.Map(input, model);
        //        await _roleRepository.UpdateAsync(model);
        //        return JsonResponse.Success();
        //    }
        //    catch (Exception ex)
        //    {
        //        return JsonResponse.ServerError();
        //    }
        //}
    }
}
