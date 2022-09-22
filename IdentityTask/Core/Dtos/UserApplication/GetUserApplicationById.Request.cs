namespace IdentityTask.Core.Dtos
{
    public class GetUserApplicationByIdRequest: BaseRequest
    {
        public Guid  Id { get; set; }
    }
}
