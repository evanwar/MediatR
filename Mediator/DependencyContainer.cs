using Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, Assembly handlerAssembly)
        {
            return services.AddSingleton<IMediator>(provider => new Mediator.Mediator(handlerAssembly));
        }
    }
}
