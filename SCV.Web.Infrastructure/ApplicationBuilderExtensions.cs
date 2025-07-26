namespace SCV.Web.Infrastructure
{
    using SCV.Data.Seeding.Contracts;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

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
