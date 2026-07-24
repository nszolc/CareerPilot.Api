using CareerPilot.Application.Validators.JobAd;                                                                        
using CareerPilot.Infrastructure.Data;                                                                                 
using FluentValidation;                                                                                                
using Microsoft.EntityFrameworkCore;   
using CareerPilot.Application.Interfaces;
using CareerPilot.Infrastructure.Repositories;
using CareerPilot.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>                                                                 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// rejestracja serwisów i repo
builder.Services.AddScoped<IJobAdRepository, JobAdRepository>();
builder.Services.AddScoped<IApplicationFileService, ApplicationFileService>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateJobAdRequestValidator>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

app.Run();