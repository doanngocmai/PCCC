using AutoMapper;
using PCCC.Common.DTOs;
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
    public class ContentService : BaseService<Content>, IContentService
    {
        private readonly IContentRepository _contentRepository;
        private readonly IMapper _mapper;
        public ContentService(IContentRepository contentRepository, IMapper mapper) : base(contentRepository)
        {
            _contentRepository = contentRepository;
            _mapper = mapper;
        }
        public async Task<JsonResultModel> CreateContent(CreateContentModel model)
        {
            try
            {
                var data = await _contentRepository.GetFirstOrDefaultAsync(x => x.Name == model.Name && x.Type == model.Type);
                if (data != null)
                    return JsonResponse.Error(PCCCConsts.ERROR_CONTENT_ALREADY_EXIST, PCCCConsts.MESSAGE_CONTENt_ALREADY_EXIST);
                Content content = new Content()
                {
                    Name = model.Name,
                    Icon = model.Icon,
                    Image = model.Image,
                    Link = model.Link,
                    Type = model.Type,
                    Color = model.Color,
                    Description = model.Description,
                    CreationTime = DateTime.Now,
                    IsActive = model.IsActive
                };
                await _contentRepository.AddAsync(content);
                return JsonResponse.Success();
            }
            catch (Exception ex)
            {
                return JsonResponse.ServerError();
            }
        }
        public async Task<JsonResultModel> GetListContent(int page, int limit, string SearchKey, int? status, string fromDate, string toDate)
        {
            try
            {
                var list = await _contentRepository.GetContents(page, limit, SearchKey, status, fromDate, toDate);
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
    }
}
