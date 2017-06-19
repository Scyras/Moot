using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moot.Environments.Extensions
{
    public static class HostingEnvironmentExtensions
    {
        public static bool IsQualityAssurance
            (this IHostingEnvironment hostingEnvironment)
        {
            return hostingEnvironment.EnvironmentName == "QualityAssurance";
        }
    }
}
