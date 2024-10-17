using KhoThoExe.DTOs;
using KhoThoExe.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KhoThoExe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobTypesController : ControllerBase
    {
        private readonly IJobTypeService _jobTypeService;

        public JobTypesController(IJobTypeService jobTypeService)
        {
            _jobTypeService = jobTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobTypeDto>>> GetAllJobTypes()
        {
            var jobTypes = await _jobTypeService.GetAllJobTypesAsync();
            return Ok(jobTypes);
        }

        // Lấy loại công việc theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<JobTypeDto>> GetJobTypeById(int id)
        {
            var jobType = await _jobTypeService.GetJobTypeByIdAsync(id);
            if (jobType == null)
            {
                return NotFound();
            }
            return Ok(jobType);
        }

        // Tạo loại công việc mới
        [HttpPost]
        public async Task<ActionResult<JobTypeDto>> CreateJobType(JobTypeDto jobTypeDto)
        {
            var createdJobType = await _jobTypeService.CreateJobTypeAsync(jobTypeDto);
            return CreatedAtAction(nameof(GetJobTypeById), new { id = createdJobType.JobTypeID }, createdJobType);
        }

        // Cập nhật loại công việc
        [HttpPut("{id}")]
        public async Task<ActionResult<JobTypeDto>> UpdateJobType(int id, JobTypeDto jobTypeDto)
        {
            var updatedJobType = await _jobTypeService.UpdateJobTypeAsync(id, jobTypeDto);
            if (updatedJobType == null)
            {
                return NotFound();
            }
            return Ok(updatedJobType);
        }

        // Xóa loại công việc
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobType(int id)
        {
            var result = await _jobTypeService.DeleteJobTypeAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent(); // 204 No Content
        }
    }
}
