namespace SCV.Data.Seeding.Contracts
{
    public interface IApplicationDbInitializer
    {
        Task SeedUsersAndRolesAsync();
    }
}
