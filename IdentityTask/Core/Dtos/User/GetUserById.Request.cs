﻿namespace IdentityTask.Core.Dtos
{
    public class GetUserByIdRequest: BaseRequest
    {
        public Guid Id { get; set; }
    }
}
