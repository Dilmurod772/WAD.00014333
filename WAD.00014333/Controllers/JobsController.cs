using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00014333.DTOs;
using WAD._00014333.Interfaces;
using WAD._00014333.Models;

namespace WAD._00014333.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobsController(IJobRepository jobRepository, IMapper mapper)
        {
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        // GET: api/Jobs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDto>>> GetJobs()
        {
            var jobs = await _jobRepository.GetAllJobsAsync();
            return Ok(_mapper.Map<IEnumerable<JobDto>>(jobs));
        }

        // GET: api/Jobs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobDto>> GetJob(int id)
        {
            var job = await _jobRepository.GetJobByIdAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return _mapper.Map<JobDto>(job);
        }

        // POST: api/Jobs
        [HttpPost]
        public async Task<ActionResult<JobDto>> PostJob(JobDto jobDto)
        {
            var job = _mapper.Map<Job>(jobDto);
            job = await _jobRepository.AddJobAsync(job);
            return CreatedAtAction(nameof(GetJob), new { id = job.JobId }, _mapper.Map<JobDto>(job));
        }

        // PUT: api/Jobs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJob(int id, JobDto jobDto)
        {
            if (id != jobDto.JobId)
            {
                return BadRequest();
            }

            var job = _mapper.Map<Job>(jobDto);
            await _jobRepository.UpdateJobAsync(job);

            return NoContent();
        }

        // DELETE: api/Jobs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            await _jobRepository.DeleteJobAsync(id);
            return NoContent();
        }
    }
}
