﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Monuments.Manager.Application.Exceptions;
using Monuments.Manager.Application.Infrastructure;
using Monuments.Manager.Application.Monuments.Extensions;
using Monuments.Manager.Application.Monuments.Models;
using Monuments.Manager.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Monuments.Queries
{
    public class GetMonumentQueryHandler : IRequestHandler<GetMonumentQuery, MonumentDto>
    {
        private readonly MonumentsDbContext _dbContext;

        public GetMonumentQueryHandler(MonumentsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MonumentDto> Handle(GetMonumentQuery request, CancellationToken cancellationToken)
        {
            var monumentEntity = await _dbContext.Monuments
                .FindAsync(request.MonumentId);

            if(monumentEntity is null)
            {
                throw new MonumentsManagerAppException(ExceptionType.EntityNotFound, $"Entity of type MonumentEntity with id {request.MonumentId} does not exists");
            }

            return monumentEntity.ToDto(monumentEntity.Pictures);
        }
    }
}
