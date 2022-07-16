﻿namespace Steam.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddGrpc();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseRouting();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGrpcService<UserService>();
        });

        app.Run();
    }
}

