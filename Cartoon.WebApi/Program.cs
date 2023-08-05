using Cartoon.Contract.Service;
using Cartoon.Core.Configs;
using Cartoon.WebApi;
using Microsoft.Extensions.Options;
using Serilog;
using Cartoon.Contract.Service;
using Cartoon.Core.Configs;
using Cartoon.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("*")
                                                          .AllowAnyHeader()
                                                          .AllowAnyMethod();
                                      // .AllowCredentials();

                                  });
        });



        _ = builder.Host.UseSerilog((hostContext, loggerConfiguration) =>
           _ = loggerConfiguration.ReadFrom.Configuration(builder.Configuration));

        var startup = new Startup(builder, builder.Environment);
        startup.ConfigureServices(builder.Services);

        var app = builder.Build();
        app.UseCors(MyAllowSpecificOrigins);
        SystemSettingModel.Configs = app.Configuration;
        OnAppStart(app);
        startup.Configure(app, builder.Environment);
        app.Run();
    }

    public static void OnAppStart(IHost host)
    {
        using var scope = host.Services.CreateScope();
        var bootstrapperService = scope.ServiceProvider.GetRequiredService<IBootstrapperService>();
        bootstrapperService.InitialAsync().Wait();
    }
}