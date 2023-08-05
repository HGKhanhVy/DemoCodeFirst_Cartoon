
using Microsoft.AspNetCore.Mvc;
using Cartoon.Contract.Repository.Models;
using Cartoon.Contract.Service;
using Cartoon.Core.Constants;
using Cartoon.Core.Exceptions;
using Cartoon.Core.Models;
using Cartoon.Core.Models.DienVienLongTieng;

namespace Cartoon.WebApi.Controllers
{
    [ApiController]
    public class DienVienLongTiengController : ControllerBase
    {
        private readonly IDienVienLongTiengService _iDienVienLongTiengService;

        public DienVienLongTiengController(IDienVienLongTiengService iDienVienLongTiengService)
        {
            _iDienVienLongTiengService = iDienVienLongTiengService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.DienVienLongTieng.GetAllDienVienLongTieng)]
        public IActionResult GetAll()
        {
            var result = _iDienVienLongTiengService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DienVienLongTiengEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DienVienLongTieng.GetDienVienLongTieng)]
        public IActionResult GetDienVienLongTiengById(string keyId)
        {
            var data = _iDienVienLongTiengService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsDienVienLongTieng.DIENVIENLONGTIENG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DienVienLongTiengEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DienVienLongTieng.AddDienVienLongTieng)]
        public async Task<IActionResult> CreateDienVienLongTieng(DienVienLongTiengModel model)
        {
            try
            {
                var result = await _iDienVienLongTiengService.CreateAsync(model);
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
        [Route(WebApiEndpoint.DienVienLongTieng.UpdateDienVienLongTieng)]
        public async Task<IActionResult> UpdateDienVienLongTieng(string keyId, DienVienLongTiengModel model)
        {
            try
            {
                await _iDienVienLongTiengService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDienVienLongTieng.UPDATE_DIENVIENLONGTIENG_SUCCESS));
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
        [Route(WebApiEndpoint.DienVienLongTieng.DeleteDienVienLongTieng)]
        public async Task<IActionResult> DeleteDienVienLongTieng(string keyId)
        {
            try
            {
                await _iDienVienLongTiengService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDienVienLongTieng.DELETE_DIENVIENLONGTIENG_SUCCESS));
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
