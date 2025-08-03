namespace SCV.Web.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;

    using System.Reflection;

    using SCV.GlCommon;


    public static class ServiceCollectionExtensions
    {
        private static readonly string ProjectInterfacePrefix = "I";
        private static readonly string ProjectServiceSuffix = "Service";

        private static readonly string ProjectRepositorySuffix = "Repository";

        public static IServiceCollection AddProjectServices(this IServiceCollection serviceCollection, Assembly serviceAssembly)
        {
            if (serviceAssembly == null)
            {
                serviceAssembly = typeof(ServiceCollectionExtensions).Assembly;
            }

            Type[] serviceClasses = serviceAssembly
                                .GetTypes()
                                .Where(t => t.IsClass
                                        && !t.IsAbstract
                                        && t.Name.EndsWith(ProjectServiceSuffix))
                                .ToArray();

            foreach (Type serviceClass in serviceClasses)
            {
               Type? serviceInterface = serviceClass
                                        .GetInterfaces()
                                        .FirstOrDefault(si => si.Name ==$"{ProjectInterfacePrefix}{serviceClass.Name}");

                if (serviceInterface == null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InterfaceNotFoundMessage, serviceClass.Name));
                }

                serviceCollection.AddScoped(serviceInterface, serviceClass);
            }

            return serviceCollection;
        }

        public static IServiceCollection AddProjectRepositories(this IServiceCollection serviceCollection, Assembly repositoryAssembly)
        {
            if (repositoryAssembly == null)
            {
                repositoryAssembly = typeof(ServiceCollectionExtensions).Assembly;
            }

            Type[] repositoryClasses = repositoryAssembly
                                .GetTypes()
                                .Where(t => t.IsClass
                                        && !t.IsAbstract
                                        && t.Name.EndsWith(ProjectRepositorySuffix))
                                .ToArray();

            foreach (Type repositoryClass in repositoryClasses)
            {
                Type? repositoryInterface = repositoryClass
                                        .GetInterfaces()
                                        .FirstOrDefault(ri => ri.Name == $"{ProjectInterfacePrefix}{repositoryClass.Name}");
                if (repositoryInterface == null)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InterfaceNotFoundMessage, repositoryClass.Name));
                }

                serviceCollection.AddScoped(repositoryInterface, repositoryClass);
            }

            return serviceCollection;
        }
    }
}
