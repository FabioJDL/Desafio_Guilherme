using System.Collections.Generic;
using System.Reflection;

namespace DesafioGuilherme.Api.CrossCutting.Assemblies
{
    public static class AssemblyUtil
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {
            return new Assembly[]
            {
                Assembly.Load("DesafioGuilherme.Api.Api"),
                Assembly.Load("DesafioGuilherme.Api.Application"),
                Assembly.Load("DesafioGuilherme.Api.Domain"),
                Assembly.Load("DesafioGuilherme.Api.Domain.Core"),
                Assembly.Load("DesafioGuilherme.Api.Infrastructure"),
                Assembly.Load("DesafioGuilherme.Api.CrossCutting")
            };
        }
    }
}
