
using Microsoft.AspNetCore.Mvc;
using Cartoon.Contract.Repository.Models;
using Cartoon.Contract.Service;
using Cartoon.Core.Constants;
using Cartoon.Core.Exceptions;
using Cartoon.Core.Models;
using Cartoon.Core.Models.PhimHoatHinh;

namespace Cartoon.WebApi.Controllers
{
    [ApiController]
    public class PhimHoatHinhController : ControllerBase
    {
        private readonly IPhimHoatHinhService _iPhimHoatHinhService;

        public PhimHoatHinhController(IPhimHoatHinhService iPhimHoatHinhService)
        {
            _iPhimHoatHinhService = iPhimHoatHinhService;
        }

        [HttpGet]
        [Route(WebApiEndpoint.PhimHoatHinh.GetAllPhimHoatHinh)]
        public IActionResult GetAll()
        {
            var result = _iPhimHoatHinhService.GetAllAsync();
            return Ok(new BaseResponseModel<ICollection<PhimHoatHinhEntity>?>(
                statusCode: StatusCodes.Status200OK,
                code: ResponseCodeConstants.SUCCESS, data: result));
        }

        [HttpGet]
        [Route(WebApiEndpoint.PhimHoatHinh.GetPhimHoatHinh)]
        public IActionResult GetPhimHoatHinhById(string keyId)
        {
            var data = _iPhimHoatHinhService.GetByKeyIdAsync(keyId);
            if (data == null)
            {
                var result = new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status400BadRequest,
                    code: ResponseCodeConstants.NOT_FOUND,
                    message: ReponseMessageConstantsPhimHoatHinh.PHIMHOATHINH_NOT_FOUND);
                return BadRequest(result);
            }

            return Ok(new BaseResponseModel<PhimHoatHinhEntity?>
                    (statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS, data: data));
        }

        [HttpPost]
        [Route(WebApiEndpoint.PhimHoatHinh.AddPhimHoatHinh)]
        public async Task<IActionResult> CreatePhimHoatHinh(PhimHoatHinhModel model)
        {
            try
            {
                var result = await _iPhimHoatHinhService.CreateAsync(model);
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
        [Route(WebApiEndpoint.PhimHoatHinh.UpdatePhimHoatHinh)]
        public async Task<IActionResult> UpdatePhimHoatHinh(string keyId, PhimHoatHinhModel model)
        {
            try
            {
                await _iPhimHoatHinhService.UpdateAsync(keyId, model);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsPhimHoatHinh.UPDATE_PHIMHOATHINH_SUCCESS));
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
        [Route(WebApiEndpoint.PhimHoatHinh.DeletePhimHoatHinh)]
        public async Task<IActionResult> DeletePhimHoatHinh(string keyId)
        {
            try
            {
                await _iPhimHoatHinhService.DeleteAsync(keyId, false);
                return Ok(new BaseResponseModel<string>(
                    statusCode: StatusCodes.Status200OK,
                    code: ResponseCodeConstants.SUCCESS,
                    data: ReponseMessageConstantsPhimHoatHinh.DELETE_PHIMHOATHINH_SUCCESS));
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
