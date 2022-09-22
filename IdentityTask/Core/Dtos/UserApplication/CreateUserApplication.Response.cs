﻿namespace IdentityTask.Core.Dtos
{
    public class CreateUserApplicationResponse: BaseResponse
    {
        public CreateUserApplicationResponse(Guid CorrelationId): base(CorrelationId) { }
        public UserApplication UserApplicationCreated { get; set; }
    }
}
