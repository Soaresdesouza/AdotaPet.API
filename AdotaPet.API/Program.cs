using AdotaPet.API.Data.Context;
using AdotaPet.API.Data.Repository;
using AdotaPet.API.Domain.Entity;
using AdotaPet.API.Domain.Interface;
using AdotaPet.API.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
   options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
// Add services to the container.
builder.Services.AddScoped<ClientRepository>()
                .AddScoped<PetRepository>()
                .AddScoped<IEventService, EventService>()
                .AddDbContext<DataBaseContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var serviceProvider = builder.Services.BuildServiceProvider();
var eventoService = serviceProvider.GetService<IEventService>();

var app = builder.Build();
eventoService.GenerateFakeData();



// Configure the HTTP request pipeline.
app.UseSwagger();


//Endpoints
app.MapPost("/proprietario/add", ([FromServices] ClientRepository repo, [FromBody] Client proprietario) =>
{
    return repo.Add(proprietario);
});

app.MapGet("/proprietario/list", ([FromServices] ClientRepository repo) =>
{
    return repo.GetAll();
});

app.MapPost("/pet/add", ([FromServices] PetRepository repo, [FromBody] Pet pet) =>
{
    return repo.Add(pet);
});

// Listar todas os pets.
app.MapGet("/pet/list", async ([FromServices] PetRepository repo) =>
{
    return Results.Ok(await repo.GetAll());
});

app.UseSwaggerUI(
    c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoAPI V1");
        c.RoutePrefix = string.Empty;
    }
);

app.Run();
