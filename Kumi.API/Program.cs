using Kumi.API.Assemblers;
using Kumi.API.Services;
using Kumi.Core;
using Kumi.Persistence;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddKumiRuntime();

builder.Services.AddScoped<ParameterAssembler>();
builder.Services.AddScoped<ToolAssembler>();
builder.Services.AddScoped<ToolService>();
builder.Services.AddScoped<ChatService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
