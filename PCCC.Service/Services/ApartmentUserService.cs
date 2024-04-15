using AutoMapper;
using PCCC.Common.DTOs;
using PCCC.Common.DTOs.Ads;
using PCCC.Common.DTOs.ApartmentUsers;
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
    public class ApartmentUserService : BaseService<ApartmentUser>, IApartmentUserService
    {
        private readonly IApartmentUserRepository _apartmentUserRepository;
        private readonly IMapper _mapper;
        public ApartmentUserService(IApartmentUserRepository apartmentUserRepository, IMapper mapper) : base(apartmentUserRepository)
        {
            _apartmentUserRepository = apartmentUserRepository;
            _mapper = mapper;
        }
        public async Task<JsonResultModel> GetListApartmentUser(ApartmentUserSearchPageResults param)
        {
            try
            {
                var list = await _apartmentUserRepository.GetApartmentUsers(param);
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
        public async Task<JsonResultModel> CreateApartmentUser(CreateApartmentUserModel model)
        {
            try
            {
                var apartmentUser = await _apartmentUserRepository.GetFirstOrDefaultAsync(x => x.BuildingId == model.BuildingId && x.FloorNumber == model.FloorNumber);
                if (apartmentUser != null)
                    return JsonResponse.Error(PCCCConsts.ERROR_CONTENT_ALREADY_EXIST, PCCCConsts.MESSAGE_CONTENT_ALREADY_EXIST);
                var data = _mapper.Map<ApartmentUser>(model);
                data.CreationTime = DateTime.Now;
                await _apartmentUserRepository.AddAsync(data );
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> UpdateApartmentUser(UpdateApartmentUserModel model)
        {
            try
            {
                var record = await _apartmentUserRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(model.Id));
                if (record == null) return JsonResponse.Error(PCCCConsts.ERROR_CONTENT_NOT_FOUND, PCCCConsts.MESSAGE_CONTENT_NOT_FOUND);
                var valid = await _apartmentUserRepository.GetFirstOrDefaultAsync(x => x.Id != model.Id && x.BuildingId == model.BuildingId && x.FloorNumber == model.FloorNumber );
                if (valid != null) return JsonResponse.Error(PCCCConsts.ERROR_CONTENT_ALREADY_EXIST, PCCCConsts.MESSAGE_CONTENT_ALREADY_EXIST);
                _mapper.Map(model, record);
                var res = await _apartmentUserRepository.UpdateAsync(record);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> DeleteApartmentUser(int ID)
        {
            try
            {
                var apartment = await _apartmentUserRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(ID));
                await _apartmentUserRepository.DeleteAsync(apartment);
                return JsonResponse.Success();
            }
            catch (Exception Ex)
            {
                return JsonResponse.ServerError();

            }
        }
    }
}
