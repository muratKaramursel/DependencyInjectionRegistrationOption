using DependencyInjectionRegistrationOption.Core.Helper.Interfaces;

namespace DependencyInjectionRegistrationOption.Core.Helper
{
    public class Operation : IOperationScoped, IOperationSingleton, IOperationTransient
    {
        public Operation()
        {
            OperationId = Guid.NewGuid();
        }

        public Guid OperationId { get; }
    }
}