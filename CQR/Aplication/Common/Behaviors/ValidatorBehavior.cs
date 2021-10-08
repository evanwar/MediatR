using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQR.Aplication.Common.Behaviors
{
    public class ValidatorBehavior<RequestType, ResponseType> :
        IPipelineBehavior<RequestType, ResponseType> where RequestType : IRequest<ResponseType>
    {
        private readonly IEnumerable<IValidator<RequestType>> validators;

        public ValidatorBehavior(IEnumerable<IValidator<RequestType>> validators)
        {
            this.validators = validators;
        }

        public Task<ResponseType> Handle(RequestType request,
            CancellationToken cancellationToken, RequestHandlerDelegate<ResponseType> next)
        {
            if (validators.Any())
            {
                var validationResults =
                    Task.WhenAll(
                        validators.Select(
                            validator => validator.ValidateAsync(request, cancellationToken)
                            )
                        );


                var failures = validationResults.
                    Result.
                    SelectMany(validationResult => validationResult.Errors).
                    Where(failure => failure != null).
                    ToList();


                if (failures.Any())
                {
                    throw new ValidationException(failures);
                }


            }

            return next();
        }
    }
}
