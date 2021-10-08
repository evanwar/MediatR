using CQR.Entities.POCOs;
using MediatR;
using System.Collections.Generic;


namespace CQR.Aplication.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<Product>>
    {
    }
}
