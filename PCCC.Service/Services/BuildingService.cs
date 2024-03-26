using AutoMapper;
using PCCC.Common.DTOs;
using PCCC.Common.DTOs.Buildings;
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
    public class BuildingService : BaseService<Building>, IBuildingService
    {
        private readonly IBuildingRepository _buildingRepository;
        private readonly IMapper _mapper;
        public BuildingService(IBuildingRepository buildingRepository, IMapper mapper) : base(buildingRepository)
        {
            _buildingRepository = buildingRepository;
            _mapper = mapper;
        }
        public async Task<JsonResultModel> GetListContent(BuildingSearchPageResults param)
        {
            try
            {
                var list = await _buildingRepository.GetBuildings(param);
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
        public async Task<JsonResultModel> CreateContent(CreateBuildingModel model)
        {
            try
            {
                var content = _mapper.Map<Building>(model);
                content.CreationTime = DateTime.Now;
                await _buildingRepository.AddAsync(content);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> UpdateContent(UpdateBuildingModel model)
        {
            try
            {
                var record = await _buildingRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(model.Id));
                if (record == null) return JsonResponse.Error(PCCCConsts.ERROR_CONTENT_NOT_FOUND, PCCCConsts.MESSAGE_CONTENT_NOT_FOUND);
                _mapper.Map(model, record);
                var res = await _buildingRepository.UpdateAsync(record);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> DeleteContent(int ID)
        {
            try
            {
                var content = await _buildingRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(ID));
                await _buildingRepository.DeleteAsync(content);
                return JsonResponse.Success();
            }
            catch (Exception Ex)
            {
                return JsonResponse.ServerError();

            }
        }
    }
}
