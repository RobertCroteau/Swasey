﻿using System;
using System.Linq;
using System.Threading.Tasks;

using Swasey.Lifecycle;
using Swasey.Model;

namespace Swasey.Commands
{
    internal class ValidateSwaggerResourceListingCommand : ILifecycleCommand
    {

        public Task<ILifecycleContext> Execute(ILifecycleContext context)
        {
            var json = context.ResourceListingJson;

            if (!json.ContainsKey("apiVersion") == null || string.IsNullOrWhiteSpace((string) json.apiVersion))
                throw new SwaseyException("apiVersion is required");

            if (!json.ContainsKey("swaggerVersion") == null || string.IsNullOrWhiteSpace((string) json.swaggerVersion))
                throw new SwaseyException("swaggerVersion is required");

            if (!json.ContainsKey("apis") == null)
                throw new SwaseyException("apis is required");

            var ctx = new LifecycleContext(context)
            {
                State = LifecycleState.Continue,
                SwaggerVersion = (string) json.swaggerVersion
            };
            ctx.ServiceMetadata = new ServiceMetadata(ctx.ServiceMetadata)
            {
                ApiVersion = (string) json.apiVersion
            };

            foreach (var item in json.apis)
            {
                if (!item.ContainsKey("path") || string.IsNullOrWhiteSpace((string) item.path))
                    throw new SwaseyException("api.path is required");

                ctx.ApiPathJsonMapping.Add((string) item.path, null);
            }

            return Task.FromResult<ILifecycleContext>(ctx);
        }

    }
}
