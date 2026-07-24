using CareerPilot.Domain.Entities;

namespace CareerPilot.Application.Interfaces;

public interface IJobAdRepository
{
    Task<List<JobAd>> GetAllAsync(CancellationToken ct = default);

    // zwraca nullable, bo rekord może nie istnieć
    Task<JobAd?> GetByIdAsync(int id, CancellationToken ct = default);

    Task AddAsync(JobAd jobAd, CancellationToken ct = default);

    // ZMIANA: Update/Delete jako synchroniczne void (było Task) — EF tylko oznacza
    // encję w change trackerze, realny zapis idzie dopiero przez SaveChangesAsync.
    void Update(JobAd jobAd);
    void Delete(JobAd jobAd);

    Task<int> SaveChangesAsync(CancellationToken ct = default);
}