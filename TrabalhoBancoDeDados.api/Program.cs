using System.Security.Authentication;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using TrabalhoBancoDeDados.Contexts;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<ClienteContext>(options =>
        {
            options.UseNpgsql("Host=localhost;Database=trabalho;Username=postgres;Password=123456");
        });

        builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect("redis-16456.c308.sa-east-1-1.ec2.cloud.redislabs.com:16456,password=m0725si9gKgyDn8grJqFx3vHXwlGUDlF"));

        builder.Services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();
            busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
            {
                busFactoryConfigurator.Host("jackal-01.rmq.cloudamqp.com", 5671, "mxixoldu", h =>
                {
                    h.Username("mxixoldu");
                    h.Password("dGSjTThRm61xWXfmKFGxi79hc_nW-awP");

                    h.UseSsl(s =>
                    {
                        s.Protocol = SslProtocols.Tls12;
                    });
                });
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}