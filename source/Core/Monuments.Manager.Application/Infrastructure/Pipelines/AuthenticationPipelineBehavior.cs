﻿using MediatR;
using Monuments.Manager.Application.Context;
using Monuments.Manager.Application.Users.Commands;
using Monuments.Manager.Persistence;
using System;
using System.Security.Authentication;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Monuments.Manager.Application.Infrastructure.Pipelines
{
    public class AuthenticationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly MonumentsDbContext _dbContext;
        private readonly MonumentsManagerContext _context;

        public AuthenticationPipelineBehavior(MonumentsDbContext dbContext,
                                             MonumentsManagerContext context)
        {
            _dbContext = dbContext;
            _context = context;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var user = await _dbContext.Users.FindAsync(_context.UserId);

            if(user is null)
            {
                throw new AuthenticationException();
            }

            return await next();
        }
    }
}