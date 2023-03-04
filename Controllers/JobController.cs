using JobsApp.Models;
using JobsApp.Repositories;
using JobsApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobsApp.Controllers
{
    public class JobController : Controller
    {
        private readonly IJob _jobRepository;

        public JobController(IJob jobRepository)
        {
            _jobRepository = jobRepository;
        }

        
        public async Task<IActionResult> Index()
        {
            var jobs = await _jobRepository.GetAllJobs();
            return View(jobs);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Job job)
        {
            var newJob = await _jobRepository.CreateJob(job);

            return RedirectToAction("Index");   
        }

        [HttpGet]

        public async Task<IActionResult> Details(Guid id)
        {
            var existingJob = await _jobRepository.GetJob(id);

            if (existingJob == null) return NotFound("Job Not Found");

            return View(existingJob);
        }

        [HttpGet]
        public async Task<IActionResult> Search(string title)
        {
            var existingJob = await _jobRepository.GetJobByTitle(title);

            if (existingJob == null) return NotFound("Job Not Found");

            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var existingJob = await _jobRepository.GetJob(id);

            if (existingJob == null) return NotFound("Job Not Found");

            return View(existingJob);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Job job)
        {
            var existingJob = await _jobRepository.UpdateJob(id, job);

            return RedirectToAction("Index");
        }

        [HttpGet] 
        public async Task<IActionResult> Delete(Guid id)
        {
            var existingJob = await _jobRepository.GetJob(id);

            if (existingJob == null) return NotFound("Job Not Found");

            return View(existingJob);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(Guid id, Job job)
        {
            await _jobRepository.DeleteJob(id);

            return RedirectToAction("Index");
        }


    }

    
}
