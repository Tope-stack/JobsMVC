using JobsApp.Models;
using JobsApp.ViewModel;

namespace JobsApp.Repositories
{
    public interface IJob
    {
        Task<IEnumerable<Job>> GetAllJobs();
        Task<Job> GetJob(Guid id);
        Task<Job> GetJobByTitle(string title);
        Task<Job> CreateJob(Job job);
        Task<Job> UpdateJob(Guid id, Job job);
        Task<Job> DeleteJob(Guid id);
    }
}
