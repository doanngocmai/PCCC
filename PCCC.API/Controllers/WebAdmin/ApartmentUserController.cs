using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCCC.Common.DTOs.ApartmentUsers;
using PCCC.Common.DTOs.Contents;
using PCCC.Common.Utils;
using PCCC.Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace PCCC.API.Controllers.WebAdmin
{
    [Route("api/web/[controller]")]
    [ApiExplorerSettings(GroupName = "WebAdmin")]
    [ApiController]
    [SwaggerTag("Advertising")]
    public class ApartmentUserController : ControllerBase
    {
        public readonly IApartmentUserService _apartmentUserService;
        public ApartmentUserController (IApartmentUserService apartmentUserService)
        {
            _apartmentUserService = apartmentUserService;
        }
        [HttpGet("GetListApartmentUser")]
        //[Authorize]
        public async Task<JsonResultModel> GetListApartmentUser([FromQuery] ApartmentUserSearchPageResults param)
        {
            return await _apartmentUserService.GetListApartmentUser(param);
        }
        //[Authorize]
        [HttpPost("CreateApartmentUser")]
        public async Task<JsonResultModel> CreateApartmentUser(CreateApartmentUserModel model)
        {
            return await _apartmentUserService.CreateApartmentUser(model);
        }
        [HttpPost("UpdateApartmentUser")]
        //[Authorize]
        public async Task<JsonResultModel> UpdateApartmentUser(UpdateApartmentUserModel input)
        {
            return await _apartmentUserService.UpdateApartmentUser(input);
        }
        [HttpDelete("DeleteApartmentUser/{ID}")]
        //[Authorize]
        public async Task<JsonResultModel> DeleteApartmentUser(int ID)
        {
            return await _apartmentUserService.DeleteApartmentUser(ID);
        }
    }
}
