
using Microsoft.AspNetCore.Mvc;
using Cartoon.Contract.Repository.Models;
using Cartoon.Contract.Service;
using Cartoon.Core.Constants;
using Cartoon.Core.Exceptions;
using Cartoon.Core.Models;
using Cartoon.Core.Models.NhanVatTrongTapPhim;

namespace Cartoon.WebApi.Controllers
{
    [ApiController]
    public class NhanVatTrongTapPhimController : ControllerBase
    {
        private readonly INhanVatTrongTapPhimService _iNhanVatTrongTapPhimService;

        public NhanVatTrongTapPhimController(INhanVatTrongTapPhimService iNhanVatTrongTapPhimService)
        {
            _iNhanVatTrongTapPhimService = iNhanVatTrongTapPhimService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhanVatTrongTapPhim.GetAllNhanVatTrongTapPhim)]
        public IActionResult GetAll()
        {
            var result = _iNhanVatTrongTapPhimService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NhanVatTrongTapPhimEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhanVatTrongTapPhim.GetNhanVatTrongTapPhim)]
        public IActionResult GetNhanVatTrongTapPhimById(string keyId)
        {
            var data = _iNhanVatTrongTapPhimService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsNhanVatTrongTapPhim.NHANVATTRONGTAPPHIM_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NhanVatTrongTapPhimEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.NhanVatTrongTapPhim.AddNhanVatTrongTapPhim)]
        public async Task<IActionResult> CreateNhanVatTrongTapPhim(NhanVatTrongTapPhimModel model)
        {
            try
            {
                var result = await _iNhanVatTrongTapPhimService.CreateAsync(model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status201Created,
                    code: ResponseCodeConstants.SUCCESS,
                    data: result));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route(WebApiEndpoint.NhanVatTrongTapPhim.UpdateNhanVatTrongTapPhim)]
        public async Task<IActionResult> UpdateNhanVatTrongTapPhim(string keyId, NhanVatTrongTapPhimModel model)
        {
            try
            {
                await _iNhanVatTrongTapPhimService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsNhanVatTrongTapPhim.UPDATE_NHANVATTRONGTAPPHIM_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }

        }

        [HttpDelete]
        [Route(WebApiEndpoint.NhanVatTrongTapPhim.DeleteNhanVatTrongTapPhim)]
        public async Task<IActionResult> DeleteNhanVatTrongTapPhim(string keyId)
        {
            try
            {
                await _iNhanVatTrongTapPhimService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsNhanVatTrongTapPhim.DELETE_NHANVATTRONGTAPPHIM_SUCCESS));
            }
            catch (Exception e)
            {
                dynamic result;
                if (e is CoreException error)
                {
                    result = new BaseResponseModel<string>(
                        statusCode: error.StatusCode,
                        code: error.Code,
                        message: error.Message);
                    return BadRequest(result);
                }
                result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status500InternalServerError,
                    code: ResponseCodeConstants.FAILED,
                    message: e.Message);
                return BadRequest(result);
            }
        }
    }
}
