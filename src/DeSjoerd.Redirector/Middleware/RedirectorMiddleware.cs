using DeSjoerd.Redirector.Core;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeSjoerd.Redirector.Middleware
{
    public class RedirectorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly RedirectConfigurationService _redirectConfigurationService;

        public RedirectorMiddleware(RequestDelegate next, RedirectConfigurationService redirectConfigurationService)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _redirectConfigurationService = redirectConfigurationService ?? throw new ArgumentNullException(nameof(redirectConfigurationService));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            foreach(var item in _redirectConfigurationService.GetRedirectConfigurations())
            {
                if(item.MatchesDomain(context.Request.Host.Host))
                {
                    context.Response.StatusCode = StatusCodes.Status302Found;
                    context.Response.Headers["Location"] = item.Target;

                    return;
                }
            }

            await _next(context);
        }
    }
}
