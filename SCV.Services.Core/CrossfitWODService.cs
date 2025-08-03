namespace SCV.Services.Core
{
    using Microsoft.EntityFrameworkCore;
    using HtmlAgilityPack;

    using System.Globalization;
    using System.Text;

    using SCV.Data.Models;
    using SCV.Data.Repository.Contracts;
    using SCV.Services.Core.Contracts;
    using SCV.Web.ViewModels.CrossfitVM;

    using static SCV.GlCommon.ApplicationConstants;

    public class CrossfitWODService : ICrossfitWODService
    {
        private readonly ICrossfitWODRepository crossfitWODRepository;

        public CrossfitWODService(ICrossfitWODRepository crossfitWODRepository)
        {
            this.crossfitWODRepository = crossfitWODRepository;
        }

        public async Task<CrossfitWODViewModel?> GetCrossfitWODByIdAsync(string id)
        {
            CrossfitWODViewModel? crossfitWODViewModel = null;

            CrossfitWorkoutOfTheDay? crossfitWODEntity = await this.crossfitWODRepository
                                        .GetByIdAsync(Guid.Parse(id));

            if(crossfitWODEntity != null)
            {
                crossfitWODViewModel = new CrossfitWODViewModel()
                {
                    Id = crossfitWODEntity.Id.ToString(),
                    Name = crossfitWODEntity.Name,
                    DescriptionHTML = crossfitWODEntity.DescriptionHTML
                };

            }

            return crossfitWODViewModel;
        }

        public async Task<CrossfitWODViewModel?> GetLatestCrossfitWODAsync()
        {
            CrossfitWODViewModel? crossfitWODVieModel = null;

            CrossfitWorkoutOfTheDay? entityCrossfitWOD = await this.crossfitWODRepository
                                                         .GetTodayWOD();

            if (entityCrossfitWOD == null)
            {
                entityCrossfitWOD = await GetWorkOutOfDay();

                if (entityCrossfitWOD != null)
                {
                    CrossfitWorkoutOfTheDay? wodExist = await this.crossfitWODRepository
                                       .GetAllAttached()
                                       .SingleOrDefaultAsync(cwod => cwod.WorkoutDate == entityCrossfitWOD.WorkoutDate &&
                                                            cwod.Name == entityCrossfitWOD.Name);

                    if (wodExist == null)
                    {
                        this.crossfitWODRepository.Add(entityCrossfitWOD);

                    }
                }
            }

            crossfitWODVieModel = new CrossfitWODViewModel()
            {
                Id = entityCrossfitWOD.Id.ToString(),
                Name = entityCrossfitWOD.Name,
                DescriptionHTML = entityCrossfitWOD.DescriptionHTML,
            };

            return crossfitWODVieModel;
        }

        public async Task<IEnumerable<CrossfitWODViewModel>> GetAllCrossfitWODAsync()
        {
            IEnumerable<CrossfitWODViewModel> allCrossfitWODViews = await this.crossfitWODRepository
                                            .GetAllAttached()
                                            .AsNoTracking()
                                            .OrderBy(wod => wod.WorkoutDate)
                                            .Select(wod => new CrossfitWODViewModel()
                                            {
                                                Id = wod.Id.ToString(),
                                                Name = wod.Name,
                                                DescriptionHTML= wod.DescriptionHTML,
                                            })
                                            .ToListAsync();

            return allCrossfitWODViews;
        }

        private async Task<CrossfitWorkoutOfTheDay?> GetWorkOutOfDay()
        {
            CrossfitWorkoutOfTheDay? crossfitWOD = null;

            DateTime todayWod = DateTime.UtcNow.AddHours(3);

            string formatDate = todayWod.ToString(DateOnlyFormatCrossfitWOD);

            string url = $"https://www.crossfit.com/{formatDate}";


            HttpClient client = new HttpClient();

            try
            {
                string html = await client.GetStringAsync(url);
                HtmlDocument htmlDocument = new HtmlDocument();

                htmlDocument.LoadHtml(html);

                HtmlNode? nameNodes = htmlDocument
                               .DocumentNode.SelectSingleNode("//div[contains(@class, '_day-text_dd8ua_124')]");

                HtmlNode? dateNodes = htmlDocument
                                 .DocumentNode.SelectSingleNode("//h2[contains(@class, '_wrapper_gubiy_95')]");

                HtmlNode? nodeText = htmlDocument
                                    .DocumentNode.SelectSingleNode("//div[contains(@class, '_wrapper_wp4uo_96')]");
                if (nodeText != null && dateNodes != null && nameNodes != null)
                {
                    StringBuilder sbPlain = new StringBuilder();
                    StringBuilder sbHtml = new StringBuilder();
                    StringBuilder sbName = new StringBuilder();
                    StringBuilder sbDate = new StringBuilder();

                    var pNodes = nodeText.SelectNodes(".//p");
                    if (pNodes != null)
                    {
                        foreach (var p in pNodes)
                        {
                            var text = p.InnerText.ToLower();
                            if (text.Contains("resources:") || text.Contains("find a gym near you")
                                || text.Contains("compare"))
                            {
                                p.Remove(); // Remove the last two paragraphs
                            }
                        }
                        sbPlain.AppendLine(nodeText.InnerText.Trim());
                        sbHtml.AppendLine(nodeText.InnerHtml.Trim());
                        sbName.AppendLine(nameNodes.InnerText.Trim());
                        sbDate.AppendLine(dateNodes.InnerText.Trim());


                        crossfitWOD = new CrossfitWorkoutOfTheDay
                        {
                            Name = $"{sbName.ToString().Trim()}/{sbDate.ToString().Trim()}",
                            WorkoutDate = DateTime.ParseExact(sbDate.ToString().Trim(), "yyMMdd", CultureInfo.InvariantCulture),
                            DescriptionPlain = sbPlain.ToString().Trim(),
                            DescriptionHTML = sbHtml.ToString().Trim()
                        };
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not fetch the WOD. The page might not be published yet. Erro: " + e.Message);
            }

            return crossfitWOD;
        }
    }
}
