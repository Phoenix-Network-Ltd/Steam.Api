using System;
using Grpc.Core;
using Rpc;
using Steam.Api.Helpers;

namespace Steam.Api.Services
{
	public class UserService : User.UserBase
	{
        public override async Task<UserResponse> GetWithTicket(GetWithTicketRequest request, ServerCallContext context)
        {
            var response = await SteamHelper.GetUser(request.Ticket, request.Appid);

            return new UserResponse
            {
                Success = response != null,
                Id = (response == null ? 0 : Convert.ToUInt64(response["steamid"])),
            };
        }
    }
}