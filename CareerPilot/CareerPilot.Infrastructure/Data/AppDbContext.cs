using Microsoft.EntityFrameworkCore;
using CareerPilot.Domain.Entities;

namespace CareerPilot.Infrastructure.Data;

public class AppDbContext : DbContext 
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<JobAd> JobAds => Set<JobAd>();
    public DbSet<ApplicationFile> ApplicationFiles => Set<ApplicationFile>();
    public DbSet<JobInterview> JobInterviews => Set<JobInterview>();
    public DbSet<EmployerMessage> EmployerMessages => Set<EmployerMessage>();
}

