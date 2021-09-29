using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mediator
{
    public class Mediator : IMediator
    {

        Assembly HandlersAssembly;


        public Mediator(Assembly HandlersAssembly)
        {
            this.HandlersAssembly = HandlersAssembly;
        }

        ReturnType Handle<ReturnType, RequestType>(RequestType request, CancellationToken cancellationToken)
        {
            ReturnType Result = default;
            Type RequestHandlerType;

            if (typeof(ReturnType).IsGenericType)
            {
                RequestHandlerType = typeof(IRequestHandler<,>);
            }
            else
            {
                RequestHandlerType = typeof(IRequestHandler<>);
            }


            Type Handler = HandlersAssembly.GetTypes().FirstOrDefault(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == RequestHandlerType
                          && i.GetGenericArguments()[0] == request.GetType()));

            if (Handler != null)
            {
                var HandlerInstace = Activator.CreateInstance(Handler);

                Result = (ReturnType)Handler.GetMethod("Handle").Invoke(HandlerInstace, new object[] { request, cancellationToken });
            }
            else
            {
                throw new InvalidOperationException(string.Format("Error, manejador no encontrado {0}", request.GetType()));
            }

            return Result;

        }



        public Task Send(IRequest request, CancellationToken cancellationToken = default)
        {
            return Handle<Task, IRequest>(request, cancellationToken);
        }

        public Task<ResponseType> Send<ResponseType>(IRequest<ResponseType> request, CancellationToken cancellationToken = default)
        {
            return Handle<Task<ResponseType>, IRequest<ResponseType>>(request, cancellationToken);
        }
    }
}
