namespace IdentityTask.Core.Interfaces
{
    public interface IEncryptService
    {
        Task<string> Encrypt(string password);
    }
}
