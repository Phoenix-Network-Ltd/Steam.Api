using Steam.Api.Services;

namespace Steam.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddGrpc();

        var app = builder.Build();

        //app.UseHttpsRedirection();
        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGrpcService<UserService>();
            endpoints.MapGrpcService<TransactionService>();
        });

        app.Run();
    }
}

