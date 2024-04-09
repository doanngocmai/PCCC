using AutoMapper;
using PCCC.Common.DTOs;
using PCCC.Common.DTOs.News;
using PCCC.Common.Utils;
using PCCC.Data.Entities;
using PCCC.Repository;
using PCCC.Repository.Interfaces;
using PCCC.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace PCCC.Service.Services
{
    public class NewService : BaseService<News>, INewService
    {
        private readonly INewRepository _newRepository;
        private readonly IMapper _mapper;
        public NewService(INewRepository newRepository, IMapper mapper) : base(newRepository)
        {
            _newRepository = newRepository;
            _mapper = mapper;
        }
        public async Task<JsonResultModel> GetListNew(NewSearchPageResults param)
        {
            try
            {
                var list = await _newRepository.GetNews(param);
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
        public async Task<JsonResultModel> CreateNew(CreateNewModel model, string? imageUrl)
        {
            try
            {
                var data = await _newRepository.GetFirstOrDefaultAsync(x => x.Title == model.Title && x.Type == model.Type);
                if (data != null)
                    return JsonResponse.Error(PCCCConsts.ERROR_CONTENT_ALREADY_EXIST, PCCCConsts.MESSAGE_CONTENT_ALREADY_EXIST);
                var news = _mapper.Map<News>(model);
                news.Image = imageUrl;
                news.CreationTime = DateTime.Now;
                await _newRepository.AddAsync(news);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> UpdateNew(UpdateNewModel model)
        {
            try
            {
                var record = await _newRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(model.Id));
                if (record == null) return JsonResponse.Error(PCCCConsts.ERROR_CONTENT_NOT_FOUND, PCCCConsts.MESSAGE_CONTENT_NOT_FOUND);
                var valid = await _newRepository.GetFirstOrDefaultAsync(x => x.Id != model.Id && x.Title == model.Title && x.Type == model.Type );
                if (valid != null) return JsonResponse.Error(PCCCConsts.ERROR_CONTENT_ALREADY_EXIST, PCCCConsts.MESSAGE_CONTENT_ALREADY_EXIST);
                _mapper.Map(model, record);
                var res = await _newRepository.UpdateAsync(record);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> DeleteNew(int ID)
        {
            try
            {
                var news = await _newRepository.GetFirstOrDefaultAsync(x => x.Id.Equals(ID));
                await _newRepository.DeleteAsync(news);
                return JsonResponse.Success();
            }
            catch (Exception Ex) 
            {
                return JsonResponse.ServerError();

            }
        }
    }
}
