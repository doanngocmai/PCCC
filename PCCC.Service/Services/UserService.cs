using AutoMapper;
using System.Text;
using System.Security.Claims;
using PCCC.Common.DTOs.Users;
using PCCC.Common.Utils;
using PCCC.Service.Services;
using PCCC.Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using PCCC.Common.DTOs.Authentications;
using PCCC.Common.DTOs;
using PCCC.Data.Entities;
using System.Reflection.Emit;

namespace PCCC.Service.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper) : base(userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        // Gender token :
        private string GenerateJwtToken(User user, string secretKey, int timeout)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                new Claim("id",user.Id.ToString()),
                new Claim("type",PCCCConsts.TOKEN_TYPE_USER)
                }),
                Expires = DateTime.UtcNow.AddHours(timeout),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public async Task<JsonResultModel> GetListUser(UserSearchPageResults param)
        {
            try
            {
                var list = await _userRepository.GetUsers(param);
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
        public async Task<JsonResultModel> Authenticate(LoginModel model, string secretKey, int timeout)
        {
            try
            {
                if (model.Phone == null || model.Password == null)
                    return JsonResponse.Error(PCCCConsts.ERROR_LOGIN_FIELDS_INVALID, PCCCConsts.MESSAGE_LOGIN_FIELDS_INVALID);
                var Us = await _userRepository.GetFirstOrDefaultAsync(x => x.Phone.Contains(model.Phone));
                if (Us == null) return JsonResponse.Error(PCCCConsts.ERROR_LOGIN_FAIL, PCCCConsts.MESSAGE_LOGIN_FAIL);
                if (!Util.CheckPass(model.Password, Us.Password)) return JsonResponse.Error(PCCCConsts.ERROR_LOGIN_FAIL_PASS, PCCCConsts.MESSAGE_LOGIN_FAIL_PASS);
                if (Us.IsActive.Equals(PCCCConsts.ACTIVE_FALSE)) return JsonResponse.Error(PCCCConsts.ERROR_LOGIN_ACCOUNT_LOCK, PCCCConsts.MESSAGE_LOGIN_ACCOUNT_LOCK);
                var token = GenerateJwtToken(Us, secretKey, timeout);
                //Us.Token = token;
                await _userRepository.UpdateAsync(Us);
                var user = _mapper.Map<UserInfoModel>(Us);
                user.Password = String.Empty;
                return JsonResponse.Success(user);
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> CreateUser(CreateUserModel model)
        {
            try
            {
                //if (!Util.validPhone(model.Phone))
                //    return JsonResponse.Error(PCCCConsts.ERROR_REGISTER_PHONE_INVALID, PCCCConsts.MESSAGE_REGISTER_PHONE_INVALID);
                var username = await _userRepository.GetFirstOrDefaultAsync(x => x.UserName == model.UserName && !x.IsDelete);
                if (username != null) return JsonResponse.Error(PCCCConsts.ERROR_USERNAME_ALREADY_EXIST, PCCCConsts.MESSAGE_USERNAME_ALREADY_EXIST);
                //if (!String.IsNullOrEmpty(model.Email))
                //{
                //    var _email = await _userRepository.GetFirstOrDefaultAsync(e => e.Email == model.Email);
                //    if (_email != null) return JsonResponse.Error(PCCCConsts.ERROR_REGISTER_EMAIL_EXIST, PCCCConsts.MESSAGE_REGISTER_EMAIL_EXIST);
                //}
                // GenPassword
                string password = Util.GenPass(model.Password);

                var userNew = _mapper.Map<User>(model);
                userNew.CreationTime = DateTime.Now;
                userNew.Password = password;
                userNew.Level = PCCCConsts.UserWebAmin;
                userNew.IsDelete = false;
                userNew.CreatorUserName = PCCCConsts.ADMIN;
                await _userRepository.AddAsync(userNew);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> UpdateUser(UpdateUserModel model)
        {
            try
            {
                var record = await _userRepository.GetFirstOrDefaultAsync(x => x.IsActive.Equals(PCCCConsts.ACTIVE) && x.Id.Equals(model.Id));
                if (record == null) return JsonResponse.Error(PCCCConsts.ERROR_USER_NOT_FOUND, PCCCConsts.MESSAGE_USER_NOT_FOUND);
                //if (!Util.validPhone(model.Phone))
                //    return JsonResponse.Error(PCCCConsts.ERROR_REGISTER_PHONE_INVALID, PCCCConsts.MESSAGE_REGISTER_PHONE_INVALID);
                //if (!Util.ValidateEmail(model.Email))
                //    return JsonResponse.Error(PCCCConsts.ERROR_REGISTER_EMAIL_INVALID, PCCCConsts.MESSAGE_REGISTER_EMAIL_INVALID);
                //var Email = await _userRepository.GetFirstOrDefaultAsync(x => x.Email.Equals(model.Email) && (x.Id != model.ID));
                var Phone = await _userRepository.GetFirstOrDefaultAsync(x => x.Phone.Equals(model.Phone) && (x.Id != model.Id));

                //if (Email != null) return JsonResponse.Error(PCCCConsts.ERROR_CODE, PCCCConsts.MESSAGE_REGISTER_EMAIL_EXIST);
                if (Phone != null) return JsonResponse.Error(PCCCConsts.ERROR_CODE, PCCCConsts.MESSAGE_REGISTER_PHONE_EXIST);

                _mapper.Map(model, record);
                await _userRepository.UpdateAsync(record);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> DeleteUser(int ID)
        {
            try
            {
                var user = await _userRepository.GetFirstOrDefaultAsync(x => x.Id == ID && !x.IsDelete);
                if (user == null) return JsonResponse.Error(PCCCConsts.ERROR_USER_NOT_FOUND, PCCCConsts.MESSAGE_USER_NOT_FOUND);
                // Xóa mềm
                user.IsDelete = PCCCConsts.IS_DELETE;
                await _userRepository.UpdateAsync(user);
                return JsonResponse.Success();
            }
            catch (Exception Ex)
            {
                return JsonResponse.ServerError();

            }
        }

    }
}
