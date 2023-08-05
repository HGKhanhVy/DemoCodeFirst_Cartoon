
using Microsoft.AspNetCore.Mvc;
using Cartoon.Contract.Repository.Models;
using Cartoon.Contract.Service;
using Cartoon.Core.Constants;
using Cartoon.Core.Exceptions;
using Cartoon.Core.Models;
using Cartoon.Core.Models.DienVienTGLongTieng;

namespace Cartoon.WebApi.Controllers
{
    [ApiController]
    public class DienVienTGLongTiengController : ControllerBase
    {
        private readonly IDienVienTGLongTiengService _iDienVienTGLongTiengService;

        public DienVienTGLongTiengController(IDienVienTGLongTiengService iDienVienTGLongTiengService)
        {
            _iDienVienTGLongTiengService = iDienVienTGLongTiengService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.DienVienTGLongTieng.GetAllDienVienTGLongTieng)]
        public IActionResult GetAll()
        {
            var result = _iDienVienTGLongTiengService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<DienVienTGLongTiengEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.DienVienTGLongTieng.GetDienVienTGLongTieng)]
        public IActionResult GetDienVienTGLongTiengById(string keyId)
        {
            var data = _iDienVienTGLongTiengService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsDienVienTGLongTieng.DIENVIENTGLONGTIENG_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<DienVienTGLongTiengEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.DienVienTGLongTieng.AddDienVienTGLongTieng)]
        public async Task<IActionResult> CreateDienVienTGLongTieng(DienVienTGLongTiengModel model)
        {
            try
            {
                var result = await _iDienVienTGLongTiengService.CreateAsync(model);
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
        [Route(WebApiEndpoint.DienVienTGLongTieng.UpdateDienVienTGLongTieng)]
        public async Task<IActionResult> UpdateDienVienTGLongTieng(string keyId, DienVienTGLongTiengModel model)
        {
            try
            {
                await _iDienVienTGLongTiengService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDienVienTGLongTieng.UPDATE_DIENVIENTGLONGTIENG_SUCCESS));
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
        [Route(WebApiEndpoint.DienVienTGLongTieng.DeleteDienVienTGLongTieng)]
        public async Task<IActionResult> DeleteDienVienTGLongTieng(string keyId)
        {
            try
            {
                await _iDienVienTGLongTiengService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsDienVienTGLongTieng.DELETE_DIENVIENTGLONGTIENG_SUCCESS));
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
