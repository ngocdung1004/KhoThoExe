using KhoThoExe.Data;
using KhoThoExe.DTOs;
using KhoThoExe.Interfaces;
using KhoThoExe.Models;
using Microsoft.EntityFrameworkCore;

namespace KhoThoExe.Services
{
    public class JobTypeService : IJobTypeService
    {
        private readonly KhoThoContext _context;

        public JobTypeService(KhoThoContext context)
        {
            _context = context;
        }
        public async Task<JobTypeDto> CreateJobTypeAsync(JobTypeDto jobTypeDto)
        {
            var jobType = new JobType
            {
                JobTypeName = jobTypeDto.JobTypeName
            };

            _context.JobTypes.Add(jobType);
            await _context.SaveChangesAsync();

            jobTypeDto.JobTypeID = jobType.JobTypeID; // Get the generated JobTypeID
            return jobTypeDto;
        }

        public async Task<bool> DeleteJobTypeAsync(int jobTypeId)
        {
            var jobType = await _context.JobTypes.FindAsync(jobTypeId);
            if (jobType == null) return false;

            _context.JobTypes.Remove(jobType);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<JobTypeDto>> GetAllJobTypesAsync()
        {
            return await _context.JobTypes.Select(j => new JobTypeDto
            {
                JobTypeID = j.JobTypeID,
                JobTypeName = j.JobTypeName
            }).ToListAsync();
        }

        public async Task<JobTypeDto> GetJobTypeByIdAsync(int jobTypeId)
        {
            var jobType = await _context.JobTypes.FindAsync(jobTypeId);
            if (jobType == null) return null;

            return new JobTypeDto
            {
                JobTypeID = jobType.JobTypeID,
                JobTypeName = jobType.JobTypeName
            };
        }

        public async Task<JobTypeDto> UpdateJobTypeAsync(int jobTypeId, JobTypeDto jobTypeDto)
        {
            var jobType = await _context.JobTypes.FindAsync(jobTypeId);
            if (jobType == null) return null;

            jobType.JobTypeName = jobTypeDto.JobTypeName;

            await _context.SaveChangesAsync();
            return jobTypeDto;
        }
    }
}
