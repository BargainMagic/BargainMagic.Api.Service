using BargainMagic.Api.Abstractions;
using BargainMagic.Api.Abstractions.Endpoints.Season.Requests;
using BargainMagic.Api.Abstractions.Handlers.Season;
using BargainMagic.Api.Core.Handlers.Season;
using BargainMagic.Api.Core.RequestValidators.Season;
using BargainMagic.Api.Service.Endpoints;
using BargainMagic.Data.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDataServices();

builder.Services.AddTransient<IApiRequestValidator<CreateSeasonRequest>, CreateSeasonRequestValidator>();
builder.Services.AddTransient<IApiRequestValidator<UpdateSeasonRequest>, UpdateSeasonRequestValidator>();

builder.Services.AddSingleton<ICreateSeasonHandler, CreateSeasonHandler>();
builder.Services.AddSingleton<IDeleteSeasonHandler, DeleteSeasonHandler>();
builder.Services.AddSingleton<IGetSeasonsHandler, GetSeasonsHandler>();
builder.Services.AddSingleton<IUpdateSeasonHandler, UpdateSeasonHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapEndpoints();

app.Run();
