using KhoThoExe.Data;
using KhoThoExe.DTOs;
using KhoThoExe.Interfaces;
using KhoThoExe.Models;
using Microsoft.EntityFrameworkCore;

namespace KhoThoExe.Services
{
    public class WorkerJobTypeService : IWorkerJobTypeService
    {
        private readonly KhoThoContext _context;

        public WorkerJobTypeService(KhoThoContext context)
        {
            _context = context;
        }

        public async Task<WorkerJobTypeDto> CreateWorkerJobTypeAsync(WorkerJobTypeDto workerJobTypeDto)
        {
            var workerJobType = new WorkerJobType
            {
                WorkerID = workerJobTypeDto.WorkerID,
                JobTypeID = workerJobTypeDto.JobTypeID
            };

            _context.WorkerJobTypes.Add(workerJobType);
            await _context.SaveChangesAsync();

            return workerJobTypeDto;
        }

        public async Task<bool> DeleteWorkerJobTypeAsync(int workerId, int jobTypeId)
        {
            var workerJobType = await _context.WorkerJobTypes
                .FirstOrDefaultAsync(wjt => wjt.WorkerID == workerId && wjt.JobTypeID == jobTypeId);

            if (workerJobType == null)
            {
                return false;
            }

            _context.WorkerJobTypes.Remove(workerJobType);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<WorkerJobTypeDto>> GetAllWorkerJobTypesAsync()
        {
            var workerJobTypes = await _context.WorkerJobTypes
                .Include(wjt => wjt.Worker)
                .Include(wjt => wjt.JobType)
                .ToListAsync();

            return workerJobTypes.Select(wjt => new WorkerJobTypeDto
            {
                WorkerID = wjt.WorkerID,
                JobTypeID = wjt.JobTypeID,
            }).ToList();
        }

        public async Task<WorkerJobTypeDto> GetWorkerJobTypeByIdAsync(int workerId, int jobTypeId)
        {
            var workerJobType = await _context.WorkerJobTypes
                .Include(wjt => wjt.JobType)
                .FirstOrDefaultAsync(wjt => wjt.WorkerID == workerId && wjt.JobTypeID == jobTypeId);

            if (workerJobType == null)
            {
                return null;
            }

            return new WorkerJobTypeDto
            {
                WorkerID = workerJobType.WorkerID,
                JobTypeID = workerJobType.JobTypeID,
            };
        }
    }
}
