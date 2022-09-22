namespace IdentityTask.Core.Interfaces
{
    public interface  ITokenClaimService
    {
        Task<string> GetTokenAsync(User user);
    }
}
