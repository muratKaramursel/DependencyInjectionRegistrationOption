using DependencyInjectionRegistrationOption.Core.Helper.Interfaces;
using Microsoft.Extensions.Logging;

namespace DependencyInjectionRegistrationOption.BLL
{
    public class DummyBusiness
    {
        private readonly ILogger<DummyBusiness> _logger;
        private readonly IOperationScoped _operationScoped;
        private readonly IOperationSingleton _operationSingleton;
        private readonly IOperationTransient _operationTransient;

        public DummyBusiness(ILogger<DummyBusiness> logger, IOperationScoped operationScoped, IOperationSingleton operationSingleton, IOperationTransient operationTransient)
        {
            _logger = logger;
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;
            _operationTransient = operationTransient;
        }

        public void DoOperation()
        {
            _logger.LogInformation($"Business   Singleton:     {_operationSingleton.OperationId}");
            _logger.LogInformation($"Business   Scoped:        {_operationScoped.OperationId}");
            _logger.LogInformation($"Business   Transient:     {_operationTransient.OperationId}");
        }
    }
}