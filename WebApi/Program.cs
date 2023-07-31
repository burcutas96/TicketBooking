using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
    options.AddPolicy("SpesificOrigins", policy => policy.WithOrigins("http://localhost:3000", "https://fly-ticket-booking-challenge.vercel.app/", "http://fly-ticket-booking-challenge.vercel.app/").AllowAnyHeader()));

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITicketDal,EfTicketDal>();
builder.Services.AddScoped<ITicketService,TicketManager>();

builder.Services.AddScoped<IFlightDal,EfFlightDal>();
builder.Services.AddScoped<IFlightService,FlightManager>();

builder.Services.AddScoped<IFlightTypeDal,EfFlightTypeDal>();
builder.Services.AddScoped<IFlightTypeService,FlightTypeManager>();

builder.Services.AddScoped<IAirportDal, EfAirportDal>();
builder.Services.AddScoped<IAirportService, AirportManager>();

builder.Services.AddScoped<IAirlineDal,EfAirlineDal>();
builder.Services.AddScoped<IAirlineService, AirlineManager>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseCors("SpesificOrigins");

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
