using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.Routing
{
    public interface IRouteProvider
    {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="routeBuilder">Route builder</param>
        void RegisterRoutes(IEndpointRouteBuilder routeBuilder);

        /// <summary>
        /// Gets a priority of route provider
        /// </summary>
        int Priority { get; }
    }
}
