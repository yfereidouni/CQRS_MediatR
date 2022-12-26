using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.MediatR.DAL.ApplicationDB;
using CQRS.MediatR.Model.Framework;
using MediatR;

namespace CQRS.MediatR.BLL.Framework
{
    public abstract class BaseApplicationServiceHandler<TRequest, TResult> : IRequestHandler<TRequest, ApplicationServiceResponse<TResult>>
            where TRequest : IRequest<ApplicationServiceResponse<TResult>>
    {
        protected readonly ApplicationDbContext _courseStoreDbContext;
        protected ApplicationServiceResponse<TResult> _response = new();

        public BaseApplicationServiceHandler(ApplicationDbContext courseStoreDbContext)
        {
            _courseStoreDbContext = courseStoreDbContext;
        }

        public async Task<ApplicationServiceResponse<TResult>> Handle(TRequest request,
            CancellationToken cancellationToken)
        {
            await HandleRequest(request, cancellationToken);
            return _response;
        }

        protected abstract Task HandleRequest(TRequest request, CancellationToken cancellationToken);

        public void AddError(string error)
        {
            _response.AddError(error);
        }
        public void AddResult(TResult result)
        {
            _response.Result = result;
        }
    }
}
