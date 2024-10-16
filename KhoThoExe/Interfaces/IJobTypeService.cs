using KhoThoExe.DTOs;

namespace KhoThoExe.Interfaces
{
    public interface IJobTypeService
    {
        Task<List<JobTypeDto>> GetAllJobTypesAsync();
        Task<JobTypeDto> GetJobTypeByIdAsync(int jobTypeId);
        Task<JobTypeDto> CreateJobTypeAsync(JobTypeDto jobTypeDto);
        Task<JobTypeDto> UpdateJobTypeAsync(int jobTypeId, JobTypeDto jobTypeDto);
        Task<bool> DeleteJobTypeAsync(int jobTypeId);
    }
}
