
using Microsoft.AspNetCore.Mvc;
using Cartoon.Contract.Repository.Models;
using Cartoon.Contract.Service;
using Cartoon.Core.Constants;
using Cartoon.Core.Exceptions;
using Cartoon.Core.Models;
using Cartoon.Core.Models.TapPhim;

namespace Cartoon.WebApi.Controllers
{
    [ApiController]
    public class TapPhimController : ControllerBase
    {
        private readonly ITapPhimService _iTapPhimService;

        public TapPhimController(ITapPhimService iTapPhimService)
        {
            _iTapPhimService = iTapPhimService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.TapPhim.GetAllTapPhim)]
        public IActionResult GetAll()
        {
            var result = _iTapPhimService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<TapPhimEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.TapPhim.GetTapPhim)]
        public IActionResult GetTapPhimById(string keyId)
        {
            var data = _iTapPhimService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsTapPhim.TAPPHIM_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<TapPhimEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.TapPhim.AddTapPhim)]
        public async Task<IActionResult> CreateTapPhim(TapPhimModel model)
        {
            try
            {
                var result = await _iTapPhimService.CreateAsync(model);
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
        [Route(WebApiEndpoint.TapPhim.UpdateTapPhim)]
        public async Task<IActionResult> UpdateTapPhim(string keyId, TapPhimModel model)
        {
            try
            {
                await _iTapPhimService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsTapPhim.UPDATE_TAPPHIM_SUCCESS));
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
        [Route(WebApiEndpoint.TapPhim.DeleteTapPhim)]
        public async Task<IActionResult> DeleteTapPhim(string keyId)
        {
            try
            {
                await _iTapPhimService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsTapPhim.DELETE_TAPPHIM_SUCCESS));
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
