namespace SCV.Data.Repository.Contracts
{
    using SCV.Data.Models;

    public interface IExerciseRepository: IAsyncRepository<Exercise,string>, IRepository<Exercise, string>
    {

    }
}
