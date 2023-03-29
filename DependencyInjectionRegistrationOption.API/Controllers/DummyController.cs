using DependencyInjectionRegistrationOption.BLL;
using DependencyInjectionRegistrationOption.Core.Helper.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionRegistrationOption.API.Controllers
{
    [Route("api/dummies")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private readonly ILogger<DummyController> _logger;
        private readonly IOperationScoped _operationScoped;
        private readonly IOperationSingleton _operationSingleton;
        private readonly IOperationTransient _operationTransient;
        private readonly DummyBusiness _dummyBusiness;

        public DummyController(
            ILogger<DummyController> logger,
            IOperationScoped operationScoped,
            IOperationSingleton operationSingleton,
            IOperationTransient operationTransient,
            DummyBusiness dummyBusiness)
        {
            _logger = logger;
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;
            _operationTransient = operationTransient;
            _dummyBusiness = dummyBusiness;
        }

        [HttpGet("first-test")]
        public async Task<IActionResult> FirstTest()
        {
            _logger.LogInformation($"FirstTestEndPoint   Singleton:     {_operationSingleton.OperationId}");
            _logger.LogInformation($"FirstTestEndPoint   Scoped:        {_operationScoped.OperationId}");
            _logger.LogInformation($"FirstTestEndPoint   Transient:     {_operationTransient.OperationId}");

            _dummyBusiness.DoOperation();

            return await Task.FromResult(Ok());
        }

        [HttpGet("second-test")]
        public async Task<IActionResult> SecondTest()
        {
            _logger.LogInformation($"SecondTestEndPoint   Singleton:     {_operationSingleton.OperationId}");
            _logger.LogInformation($"SecondTestEndPoint   Scoped:        {_operationScoped.OperationId}");
            _logger.LogInformation($"SecondTestEndPoint   Transient:     {_operationTransient.OperationId}");

            _dummyBusiness.DoOperation();

            return await Task.FromResult(Ok());
        }
    }
}