namespace SCV.Test.IntegrationTests
{
    using Microsoft.EntityFrameworkCore;
    using SCV.Data;
    using SCV.Data.Models;
    using SCV.Data.Repository;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.StoreServices;
    using SCV.Services.Core.StoreServices.Contracts;
    using SCV.Web.ViewModels.Administration.StoreVM.MembershipsVM;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class MembershipTest
    {
        //Testing but fails to load the json file for seed
        //[Test]
        //public async Task AddMembership_ShouldAddToDatabase()
        //{
        //    var options = new DbContextOptionsBuilder<SportCenterDbContext>()
        //                    .UseInMemoryDatabase("TestDb")
        //                    .Options;

        //    using SportCenterDbContext context = new SportCenterDbContext(options);

        //    string outputDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        //    string seedFilePath = Path.Combine(outputDir, "SeedFiles", "CrossFitClasses", "crossfitClassesSeed.json");

        //    string json = File.ReadAllText(seedFilePath);

        //    IList<Membership>? seededMemberships = JsonSerializer
        //                            .Deserialize<List<Membership>>(json);

        //    if (seededMemberships != null)
        //    {
        //        context.Memberships.AddRange(seededMemberships);
        //        await context.SaveChangesAsync();
        //    }


        //    IMembershipRepository repo = new MembershipRepository(context);
        //    IMembershipService service = new MembershipService(repo);

        //    await service.AddMembershipAsync(new MembershipAddViewModel { Name = "Premium" });

        //    Assert.That(context.Memberships.Count(), Is.EqualTo(1));
        //}
    }
}
