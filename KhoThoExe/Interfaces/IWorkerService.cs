using KhoThoExe.DTOs;

namespace KhoThoExe.Interfaces
{
    public interface IWorkerService
    {
        Task<List<WorkerDto>> GetAllWorkersAsync();
        Task<WorkerDto> GetWorkerByIdAsync(int workerId);
        Task<WorkerDto> CreateWorkerAsync(WorkerDto workerDto);
        Task<WorkerDto> UpdateWorkerAsync(int workerId, WorkerDto workerDto);
        Task<bool> DeleteWorkerAsync(int workerId);
    }
}
