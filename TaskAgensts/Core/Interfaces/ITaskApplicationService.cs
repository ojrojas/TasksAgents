namespace TaskAgents.Core.Interfaces
{
    public interface ITaskApplicationService
    {
        Task<CreateTaskApplicationResponse> CreateTaskApplicationAsync(CreateTaskApplicationRequest request, CancellationToken cancellationToken);
        Task<DeleteTaskApplicationResponse> DeleteTaskApplicationAsync(DeleteTaskApplicationRequest request, CancellationToken cancellationToken);
        Task<UpdateTaskApplicationResponse> UpdateTaskApplicationAsync(UpdateTaskApplicationRequest request, CancellationToken cancellationToken);
        Task<GetAllTaskApplicationResponse> GetAllTaskApplicationAsync(GetAllTaskApplicationRequest request, CancellationToken cancellationToken);
        Task<GetTaskApplicationByIdResponse> GetTaskApplicationByIdAsync(GetTaskApplicationByIdRequest request, CancellationToken cancellationToken);
    }
}
