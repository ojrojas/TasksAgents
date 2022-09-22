namespace TaskAgents.Core.Interfaces
{
    public interface IActivityTaskService
    {
        Task<CreateActivityTaskResponse> CreateActivityAsync(CreateActivityTaskRequest request, CancellationToken cancellationToken);
        Task<UpdateActivityResponse> UpdateActivityAsync(UpdateActivityRequest request, CancellationToken cancellationToken);
        Task<DeleteActivityTaskResponse> DeleteActivityAsync(DeleteActivityTaskRequest request, CancellationToken cancellationToken);
        Task<GetAllActivityTaskResponse> GetAllActivityAsync(GetAllActivityTaskRequest request, CancellationToken cancellationToken);
    }
}
