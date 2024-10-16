using KhoThoExe.Data;
using KhoThoExe.DTOs;
using KhoThoExe.Interfaces;
using KhoThoExe.Models;
using Microsoft.EntityFrameworkCore;

namespace KhoThoExe.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly KhoThoContext _context;

        public WorkerService(KhoThoContext context)
        {
            _context = context;
        }
        public async Task<WorkerDto> CreateWorkerAsync(WorkerDto workerDto)
        {
            var worker = new Worker
            {
                UserID = workerDto.UserID,
                JobType = workerDto.JobType,
                ExperienceYears = workerDto.ExperienceYears,
                Rating = workerDto.Rating,
                Bio = workerDto.Bio,
                Verified = workerDto.Verified
            };

            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();

            workerDto.WorkerID = worker.WorkerID;
            return workerDto;
        }

        public async Task<bool> DeleteWorkerAsync(int workerId)
        {
            var worker = await _context.Workers.FindAsync(workerId);
            if (worker == null)
            {
                return false;
            }

            _context.Workers.Remove(worker);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<WorkerDto>> GetAllWorkersAsync()
        {
            var workers = await _context.Workers.ToListAsync();
            return workers.Select(w => new WorkerDto
            {
                WorkerID = w.WorkerID,
                UserID = w.UserID,
                JobType = w.JobType,
                ExperienceYears = w.ExperienceYears,
                Rating = w.Rating,
                Bio = w.Bio,
                Verified = w.Verified
            }).ToList();
        }

        public async Task<WorkerDto> GetWorkerByIdAsync(int workerId)
        {
            var worker = await _context.Workers.FindAsync(workerId);
            if (worker == null)
            {
                return null;
            }

            return new WorkerDto
            {
                WorkerID = worker.WorkerID,
                UserID = worker.UserID,
                JobType = worker.JobType,
                ExperienceYears = worker.ExperienceYears,
                Rating = worker.Rating,
                Bio = worker.Bio,
                Verified = worker.Verified
            };
        }

        public async Task<WorkerDto> UpdateWorkerAsync(int workerId, WorkerDto workerDto)
        {
            var worker = await _context.Workers.FindAsync(workerId);
            if (worker == null)
            {
                return null;
            }

            worker.JobType = workerDto.JobType;
            worker.ExperienceYears = workerDto.ExperienceYears;
            worker.Rating = workerDto.Rating;
            worker.Bio = workerDto.Bio;
            worker.Verified = workerDto.Verified;

            _context.Workers.Update(worker);
            await _context.SaveChangesAsync();

            return workerDto;
        }
    }
}
