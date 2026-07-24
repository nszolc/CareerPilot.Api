using CareerPilot.Infrastructure.Data;
using CareerPilot.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using CareerPilot.Domain.Entities;

namespace CareerPilot.Infrastructure.Repositories;

public class JobAdRepository(AppDbContext db) : IJobAdRepository
{

    public async Task<List<JobAd>> GetAllAsync(CancellationToken ct = default)
    {
        return await db.JobAds.AsNoTracking().ToListAsync(ct);
    }

    public async Task<JobAd?> GetByIdAsync(int id, CancellationToken ct = default)
    {
        return await db.JobAds.SingleOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task AddAsync(JobAd jobAd, CancellationToken ct = default)
    {
        await db.JobAds.AddAsync(jobAd, ct);
    }
    
    public void Update(JobAd jobAd) => db.JobAds.Update(jobAd);
    
    public void Delete(JobAd jobAd) => db.JobAds.Remove(jobAd);
    //synchroniczne void, ponieważ nie zmienia nic w bazie
    
    public async Task<int> SaveChangesAsync(CancellationToken ct = default)
    {
        return await db.SaveChangesAsync(ct);
    }
}
