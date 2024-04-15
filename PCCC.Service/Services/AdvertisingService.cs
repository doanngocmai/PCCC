using AutoMapper;
using PCCC.Common.DTOs;
using PCCC.Common.DTOs.Ads;
using PCCC.Common.DTOs.Contents;
using PCCC.Common.Utils;
using PCCC.Data.Entities;
using PCCC.Repository;
using PCCC.Repository.Interfaces;
using PCCC.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Service.Services
{
    public class AdvertisingService : BaseService<Advertisement>, IAdvertisingService
    {
        private readonly IAdvertisingRepository _advertisingRepository;
        private readonly IMapper _mapper;
        public AdvertisingService(IAdvertisingRepository advertisingRepository, IMapper mapper) : base(advertisingRepository)
        {
            _advertisingRepository = advertisingRepository;
            _mapper = mapper;
        }
        public async Task<JsonResultModel> GetListAds(AdsSearchPageResults param)
        {
            try
            {
                var list = await _advertisingRepository.GetAds(param);
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
        public async Task<JsonResultModel> CreateAds(CreateAdsModel model)
        {
            try
            {
                var data = await _advertisingRepository.GetFirstOrDefaultAsync(x => x.Name == model.Name && x.Type == model.Type);
                if (data != null)
                    return JsonResponse.Error(PCCCConsts.ERROR_CONTENT_ALREADY_EXIST, PCCCConsts.MESSAGE_CONTENT_ALREADY_EXIST);
                var ads = _mapper.Map<Advertisement>(model);
                ads.CreationTime = DateTime.Now;
                await _advertisingRepository.AddAsync(ads);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> UpdateAds(UpdateAdsModel model)
        {
            try
            {
                var record = await _advertisingRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(model.Id));
                if (record == null) return JsonResponse.Error(PCCCConsts.ERROR_CONTENT_NOT_FOUND, PCCCConsts.MESSAGE_CONTENT_NOT_FOUND);
                var valid = await _advertisingRepository.GetFirstOrDefaultAsync(x => x.Id != model.Id && x.Name == model.Name && x.Type == model.Type );
                if (valid != null) return JsonResponse.Error(PCCCConsts.ERROR_CONTENT_ALREADY_EXIST, PCCCConsts.MESSAGE_CONTENT_ALREADY_EXIST);
                _mapper.Map(model, record);
                var res = await _advertisingRepository.UpdateAsync(record);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> DeleteAds(int ID)
        {
            try
            {
                var content = await _advertisingRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(ID));
                await _advertisingRepository.DeleteAsync(content);
                return JsonResponse.Success();
            }
            catch (Exception Ex)
            {
                return JsonResponse.ServerError();

            }
        }
    }
}
