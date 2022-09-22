namespace TaskAgents.Core.Interfaces
{
    public interface ITypeTaskService
    {
        Task<CreateTypeTaskResponse> CreateTypeTaskAsync(CreateTypeTaskRequest request, CancellationToken cancellationToken);
        Task<UpdateTypeTaskResponse> UpdateTypeTaskAsync(UpdateTypeTaskRequest request, CancellationToken cancellationToken);
        Task<DeleteTypeTaskResponse> DeleteTypeTaskAsync(DeleteTypeTaskRequest request, CancellationToken cancellationToken);
        Task<GetAllTypeTaskResponse> GetAllTypeTaskAsync(GetAllTypeTaskRequest request, CancellationToken cancellationToken);
    }
}
