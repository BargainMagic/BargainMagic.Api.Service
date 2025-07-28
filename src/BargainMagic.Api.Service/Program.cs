using BargainMagic.Api.Abstractions.Handlers.Season;
using BargainMagic.Api.Core.Handlers.Season;
using BargainMagic.Api.Service.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGetSeasonsHandler, GetSeasonsHandler>();

var app = builder.Build();

EndpointBundle.MapEndpoints(app);

app.Run();
