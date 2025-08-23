using BargainMagic.Api.Core;
using BargainMagic.Api.Service.Endpoints;
using BargainMagic.Capture.Core;
using BargainMagic.Data.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataServices();

builder.Services.AddCaptureServices();

builder.Services.AddApiServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();

app.Run();
