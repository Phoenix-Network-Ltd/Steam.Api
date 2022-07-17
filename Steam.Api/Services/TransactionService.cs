using System;
using Grpc.Core;
using Rpc;

namespace Steam.Api.Services
{
    public class TransactionService : Transaction.TransactionBase
    {
        public override Task<CreateTransactionResponse> Create(CreateTransactionRequest request, ServerCallContext context)
        {
            return base.Create(request, context);
        }
    }
}