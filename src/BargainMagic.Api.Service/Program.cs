using BargainMagic.Api.Abstractions.Handlers.Season;
using BargainMagic.Api.Core.Handlers.Season;
using BargainMagic.Api.Service.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IGetSeasonHandler, GetSeasonHandler>();
builder.Services.AddSingleton<IGetSeasonsHandler, GetSeasonsHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

EndpointBundle.MapEndpoints(app);

app.Run();
