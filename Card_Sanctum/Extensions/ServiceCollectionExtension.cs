namespace Microsoft.Extensions.DependencyInjection
{
    using Card_Sanctum.Infrastructure.Data.Common.Repository;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            return services;
        }
    }
}
