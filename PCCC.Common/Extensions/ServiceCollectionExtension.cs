using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PCCC.Common.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void RegisterTransient(this IServiceCollection serviceCollection,
                                                     Type requiredInterface,
                                                     List<Type> typesToExclude = null)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            serviceCollection.Scan(scan => scan
                .FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo(requiredInterface)
                    .Where(x => typesToExclude == null || typesToExclude.Contains(x) == false))
                .UsingRegistrationStrategy(RegistrationStrategy.Replace(ReplacementBehavior.ImplementationType))
                .AsMatchingInterface()
                .WithTransientLifetime());
        }
    }

}
