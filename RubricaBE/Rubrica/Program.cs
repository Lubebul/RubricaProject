using Microsoft.AspNetCore.Http.Json;
using Rubrica.API.Models.Converter;
using Rubrica.Application.Interfaces;
using Rubrica.Infrastructure.Extensions;
using Rubrica.Infrastructure.Repository;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new DateOnlyJsonConverter());
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.ConfigureInfrastructureDipendencyInjection(
    builder.Configuration.GetConnectionString("DefaultConnection"));

//permette la comunicazione con Frontend Angular durante lo sviluppo
builder.Services.AddCors(opts => {
    opts.AddPolicy("AllowAngularDev", p =>
      p.WithOrigins("http://localhost:4200")
       .AllowAnyMethod()
       .AllowAnyHeader()
    );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngularDev");



app.UseAuthorization();

app.MapControllers();

app.Run();
