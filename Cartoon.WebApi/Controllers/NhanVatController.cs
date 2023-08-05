
using Microsoft.AspNetCore.Mvc;
using Cartoon.Contract.Repository.Models;
using Cartoon.Contract.Service;
using Cartoon.Core.Constants;
using Cartoon.Core.Exceptions;
using Cartoon.Core.Models;
using Cartoon.Core.Models.NhanVat;

namespace Cartoon.WebApi.Controllers
{
    [ApiController]
    public class NhanVatController : ControllerBase
    {
        private readonly INhanVatService _iNhanVatService;

        public NhanVatController(INhanVatService iNhanVatService)
        {
            _iNhanVatService = iNhanVatService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhanVat.GetAllNhanVat)]
        public IActionResult GetAll()
        {
            var result = _iNhanVatService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<NhanVatEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.NhanVat.GetNhanVat)]
        public IActionResult GetNhanVatById(string keyId)
        {
            var data = _iNhanVatService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsNhanVat.NHANVAT_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<NhanVatEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.NhanVat.AddNhanVat)]
        public async Task<IActionResult> CreateNhanVat(NhanVatModel model)
        {
            try
            {
                var result = await _iNhanVatService.CreateAsync(model);
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
        [Route(WebApiEndpoint.NhanVat.UpdateNhanVat)]
        public async Task<IActionResult> UpdateNhanVat(string keyId, NhanVatModel model)
        {
            try
            {
                await _iNhanVatService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsNhanVat.UPDATE_NHANVAT_SUCCESS));
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
        [Route(WebApiEndpoint.NhanVat.DeleteNhanVat)]
        public async Task<IActionResult> DeleteNhanVat(string keyId)
        {
            try
            {
                await _iNhanVatService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsNhanVat.DELETE_NHANVAT_SUCCESS));
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
