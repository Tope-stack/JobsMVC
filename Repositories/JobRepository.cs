using JobsApp.DataContext;
using JobsApp.Models;
using JobsApp.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;


namespace JobsApp.Repositories
{
    public class JobRepository : IJob
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Job> CreateJob(Job job)
        {
            var newJob = await _context.jobs.AddAsync(new Job
            {
                Id = Guid.NewGuid(),
                Title = job.Title,
                Qualification = job.Qualification,
                Experience = job.Experience,
                Specialization = job.Specialization,
                ApplicationDate = job.ApplicationDate, 
                Salary = job.Salary,
                JobType = job.JobType,
                CompanyName = job.CompanyName,
                Website = job.Website,
                Email = job.Email,
                CompanyAddress = job.CompanyAddress,
                Country = job.Country,
                State = job.State
            });

            await _context.SaveChangesAsync();

            return job;
        }

        public async Task<Job> DeleteJob(Guid id)
        {
            var existingJob = await _context.jobs.FirstOrDefaultAsync(x => x.Id == id);

            if (existingJob == null) return null;

            _context.jobs.Remove(existingJob);
            await _context.SaveChangesAsync();

            return existingJob;
        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            return await _context.jobs.ToListAsync();
        }

        public async Task<Job> GetJobByTitle(string title)
        {
            var existingJob = await _context.jobs.FirstOrDefaultAsync(x => x.Title == title);

            return existingJob == null ? null : existingJob;
        }
        
        public async Task<Job> GetJob(Guid id)
        {
            var existingJob = await _context.jobs.FirstOrDefaultAsync(x => x.Id == id);

            return existingJob == null ? null : existingJob;
        }

        public async Task<Job> UpdateJob(Guid id, Job job)
        {
            var existingJob = await _context.jobs.FindAsync(id);

            if (existingJob == null)
            {
                throw new ArgumentException($"Job with Title {id} not found");
            }

            _context.Entry(existingJob).CurrentValues.SetValues(job);

            await _context.SaveChangesAsync();

            return existingJob;
        }

        //public async Task<Job> UpdateJob(Guid id,Job job)
        //{
        //    var existingJob = await _context.jobs.FirstOrDefaultAsync(x => x.Id == id);

        //    existingJob.Title = job.Title;
        //    existingJob.Qualification = job.Qualification;
        //    existingJob.Experience = job.Experience;
        //    existingJob.Specialization = job.Specialization;
        //    existingJob.ApplicationDate = job.ApplicationDate;
        //    existingJob.Salary = job.Salary;
        //    existingJob.JobType = job.JobType;
        //    existingJob.CompanyName = job.CompanyName;
        //    existingJob.Website = job.Website;
        //    existingJob.Email = job.Email;
        //    existingJob.CompanyAddress = job.CompanyAddress;
        //    existingJob.Country = job.Country;
        //    existingJob.State = job.State;


        //    _context.jobs.Update(job);
        //    await _context.SaveChangesAsync();

        //    return existingJob;

        //}





    }
}
