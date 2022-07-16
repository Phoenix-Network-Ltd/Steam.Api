using System;
using Grpc.Core;
using Rpc;

namespace Steam.Api.Services
{
	public class UserService : User.UserBase
	{
        public override Task<UserResponse> GetWithTicket(GetWithTicketRequest request, ServerCallContext context)
        {
            return base.GetWithTicket(request, context);
        }
    }
}