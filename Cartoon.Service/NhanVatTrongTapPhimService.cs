
using AutoMapper;
using Invedia.DI.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Cartoon.Contract.Repository.Interface;
using Cartoon.Contract.Repository.Models;
using Cartoon.Contract.Service;
using Cartoon.Core.Constants;
using Cartoon.Core.Exceptions;
using Cartoon.Core.Models.NhanVatTrongTapPhim;

namespace Cartoon.Service
{
    [ScopedDependency(ServiceType = typeof(INhanVatTrongTapPhimService))]
    public class NhanVatTrongTapPhimService : Base.Service, INhanVatTrongTapPhimService
    {

        private readonly INhanVatTrongTapPhimRepository _phamviRepository;
        private readonly IMapper _mapper;
        ILogger _logger;

        public NhanVatTrongTapPhimService(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _phamviRepository = serviceProvider.GetRequiredService<INhanVatTrongTapPhimRepository>();
            _mapper = serviceProvider.GetRequiredService<IMapper>();
            _logger = Log.Logger;
        }

        public Task<string> CreateAsync(NhanVatTrongTapPhimModel model, CancellationToken cancellationToken = default)
        {
            if (_phamviRepository.Get(_ => _.KeyId == model.KeyId && _.DeletedTime == null).Any())
            {
                _logger.Information(ErrorCode.NotUnique, model.KeyId);
                throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhanVatTrongTapPhim.NHANVATTRONGTAPPHIM_EXISTED, statusCode: StatusCodes.Status400BadRequest);
            }
            var entity = _mapper.Map<NhanVatTrongTapPhimEntity>(model);
            _phamviRepository.Add(entity);
            UnitOfWork.SaveChange();
            return Task.FromResult(entity.Id);
        }

        public Task DeleteAsync(string id, bool isPhysical, CancellationToken cancellationToken = default)
        {
            var entity = _phamviRepository.GetTracking(x => x.KeyId == id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhanVatTrongTapPhim.NHANVATTRONGTAPPHIM_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            _phamviRepository.Delete(entity, isPhysicalDelete: isPhysical);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }

        public ICollection<NhanVatTrongTapPhimEntity> GetAllAsync()
        {
            var entities = _phamviRepository.Get(_ => _.DeletedTime == null).ToList();
            return (ICollection<NhanVatTrongTapPhimEntity>)entities;
        }

        public NhanVatTrongTapPhimEntity GetByKeyIdAsync(string id)
        {
            var entity = _phamviRepository.GetSingle(_ => _.KeyId == id && _.DeletedTime == null);
            return entity;
        }

        public Task UpdateAsync(string Id, NhanVatTrongTapPhimModel model, CancellationToken cancellationToken = default)
        {
            var entity = _phamviRepository.GetTracking(x => x.KeyId == Id && x.DeletedTime == null).FirstOrDefault();
            if (entity == null)
            {
                _logger.Information(ErrorCode.NotFound, Id);
                throw new CoreException(code: ResponseCodeConstants.NOT_FOUND, message: ReponseMessageConstantsNhanVatTrongTapPhim.NHANVATTRONGTAPPHIM_NOT_FOUND, statusCode: StatusCodes.Status404NotFound);
            }
            if (model.KeyId != Id)
            {
                var isDuplicate = _phamviRepository.GetTracking(x => x.KeyId == model.KeyId && x.DeletedTime == null).FirstOrDefault();
                if (isDuplicate != null)
                {
                    _logger.Information(ErrorCode.NotUnique, Id);
                    throw new CoreException(code: ResponseCodeConstants.EXISTED, message: ReponseMessageConstantsNhanVatTrongTapPhim.NHANVATTRONGTAPPHIM_EXISTED, statusCode: StatusCodes.Status400BadRequest);
                }

            }

            _mapper.Map(model, entity);
            _phamviRepository.Update(entity);
            UnitOfWork.SaveChange();
            return Task.CompletedTask;
        }
    }
}
