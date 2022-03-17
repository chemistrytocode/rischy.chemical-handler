using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using rischy.chemical_handler.MongoDB;
using rischy.chemical_handler.Services;

var builder = WebApplication.CreateBuilder(args);

// Add configuration
builder.Services.Configure<ChemicalStoreDatabaseSettings>(
    builder.Configuration.GetSection("ChemicalStoreDatabase"));

// Add services
builder.Services.AddSingleton<ChemicalService>();

// Add controllers
builder.Services.AddControllers();

// Add Swagger
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// ToDo: Add Https endpoint back in applicationUrl launchSettings to enable https
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();