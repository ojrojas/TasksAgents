namespace IdentityTask.Core.Interfaces
{
    public interface IUserApplicationService
    {
        Task<CreateUserApplicationResponse> CreateUserApplicationAsync(CreateUserApplicationRequest request, CancellationToken cancellationToken);
        Task<UpdateUserApplicationResponse> UpdateUserApplicationAsync(UpdateUserApplicationRequest request, CancellationToken cancellationToken);
        Task<DeleteUserApplicationResponse> DeleteUserApplicationAsync(DeleteUserApplicationRequest request, CancellationToken cancellationToken);
        Task<GetUserApplicationByIdResponse> GetUserApplicationByIdAsync(GetUserApplicationByIdRequest request, CancellationToken cancellationToken);
        Task<LoginUserApplicationResponse> LoginUserApplicationAsync(LoginUserApplicationRequest request, CancellationToken cancellationToken);

    }
}
