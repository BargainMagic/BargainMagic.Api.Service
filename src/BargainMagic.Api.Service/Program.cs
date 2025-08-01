using BargainMagic.Api.Abstractions.Handlers.Season;
using BargainMagic.Api.Core.Handlers.Season;
using BargainMagic.Api.Service.Endpoints;
using BargainMagic.Data.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataServices();

builder.Services.AddSingleton<ICreateSeasonHandler, CreateSeasonHandler>();
builder.Services.AddSingleton<IGetSeasonsHandler, GetSeasonsHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();

app.Run();
