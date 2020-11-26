using Bayi.Business.IService;
using Bayi.Business.IServiceRepository;
using Bayi.Business.UnitOfWork;
using Bayi.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bayi.Business.Service
{
    public class ErrorService:IErrorService
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ErrorService(IErrorRepository errorRepository,IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Error error)
        {
            _errorRepository.Add(error);
            _unitOfWork.SaveChanges();
        }
    }
}
