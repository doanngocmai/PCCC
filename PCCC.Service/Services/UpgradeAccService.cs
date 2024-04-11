using AutoMapper;
using PCCC.Common.Utils;
using PCCC.Service.Services;
using PCCC.Common.DTOs.Roles;
using PCCC.Data.Entities;
using PCCC.Common.DTOs;
using PCCC.Repository.Interfaces;
using PCCC.Common.DTOs.UpgradeAccs;

namespace PCCCC.Service.Services
{
    public class UpgradeAccService : BaseService<UpgradeAccount>, IUpgradeAccService
    {
        private readonly IUpgradeAccRepository _upgradeAccRepository;
        private readonly IMapper _mapper;
        public UpgradeAccService(IUpgradeAccRepository upgradeAccRepository, IMapper mapper) : base(upgradeAccRepository)
        {
            _upgradeAccRepository = upgradeAccRepository;
            _mapper = mapper;
        }
        public async Task<JsonResultModel> GetListUpgradeAccount(UpgradeAccSearchPageResult param)
        {
            try
            {
                var list = await _upgradeAccRepository.GetUpgrateAccs(param);
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
        public async Task<JsonResultModel> CreateUpgradeAcc(CreateUpgradeAccModel model)
        {   
            try
            {
                var upgradeAccount = _mapper.Map<UpgradeAccount>(model);
                upgradeAccount.CreationTime = DateTime.Now;
                await _upgradeAccRepository.AddAsync(upgradeAccount);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> UpdateUpgradeAcc(UpdateUpgradeAccModel model)
        {
            try
            {
                var record = await _upgradeAccRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(model.Id));
                if (record == null) return JsonResponse.Error(PCCCConsts.ERROR_ROLE_NOT_FOUND, PCCCConsts.MESSAGE_ROLE_NOT_FOUND);
                _mapper.Map(model, record);
                await _upgradeAccRepository.UpdateAsync(record);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> DeleteUpgradeAcc(int ID)
        {
            try
            {
                var upgradeAccount = await _upgradeAccRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(ID));
                if (upgradeAccount == null) return JsonResponse.Error(PCCCConsts.ERROR_ROLE_NOT_FOUND, PCCCConsts.MESSAGE_ROLE_NOT_FOUND);
                //Xóa cứng
                await _upgradeAccRepository.DeleteAsync(upgradeAccount);
                return JsonResponse.Success();
            }
            catch (Exception Ex)
            {
                return JsonResponse.ServerError();

            }
        }

       
       
    }
}
