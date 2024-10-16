using KhoThoExe.DTOs;

namespace KhoThoExe.Interfaces
{
    public interface IWorkerJobTypeService
    {
        Task<List<WorkerJobTypeDto>> GetAllWorkerJobTypesAsync();
        Task<WorkerJobTypeDto> GetWorkerJobTypeByIdAsync(int workerId, int jobTypeId);
        Task<WorkerJobTypeDto> CreateWorkerJobTypeAsync(WorkerJobTypeDto workerJobTypeDto);
        Task<bool> DeleteWorkerJobTypeAsync(int workerId, int jobTypeId);
    }
}
