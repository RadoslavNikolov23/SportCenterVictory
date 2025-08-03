namespace SCV.Web.Infrastructure
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    using SCV.Data.Seeding.Contracts;

    public static class ApplicationBuilderExtensions
    {
        public static async Task SeedDatabaseAsync(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            IApplicationDbInitializer initializer = scope.ServiceProvider.GetRequiredService<IApplicationDbInitializer>();

            await initializer.SeedUsersAndRolesAsync();
        }
    }
}
