using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Book.Core.Routing
{
    public interface IRoutePublisher
    {
        /// <summary>
        /// Register routes
        /// </summary>
        /// <param name="routeBuilder">End point Route builder</param>
        void RegisterRoutes(IEndpointRouteBuilder routeBuilder);
    }
}
