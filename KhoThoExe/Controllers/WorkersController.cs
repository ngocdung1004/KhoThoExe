using KhoThoExe.DTOs;
using KhoThoExe.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KhoThoExe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkersController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkerDto>>> GetAllWorkers()
        {
            var workers = await _workerService.GetAllWorkersAsync();
            return Ok(workers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkerDto>> GetWorkerById(int id)
        {
            var worker = await _workerService.GetWorkerByIdAsync(id);
            if (worker == null) return NotFound();
            return Ok(worker);
        }

        [HttpPost]
        public async Task<ActionResult> CreateWorker(WorkerDto workerDto)
        {
            await _workerService.CreateWorkerAsync(workerDto);
            return CreatedAtAction(nameof(GetWorkerById), new { id = workerDto.WorkerID }, workerDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWorker(int id, WorkerDto workerDto)
        {
            if (id != workerDto.WorkerID) return BadRequest();
            await _workerService.UpdateWorkerAsync(id, workerDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorker(int id)
        {
            await _workerService.DeleteWorkerAsync(id);
            return NoContent();
        }
    }
}
