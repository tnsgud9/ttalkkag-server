using AuthServer;
using AuthServer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

var config = new Config(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddSingleton(config);

// Add services to the container.
builder.Services.AddGrpc();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();