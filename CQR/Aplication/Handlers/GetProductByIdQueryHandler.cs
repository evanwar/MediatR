﻿using CQR.Aplication.Queries;
using CQR.DBContext;
using CQR.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQR.Aplication.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductContext context;

        public GetProductByIdQueryHandler(IProductContext context)
        {
            this.context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await context.GetById(request.Id);
        }
    }
}
