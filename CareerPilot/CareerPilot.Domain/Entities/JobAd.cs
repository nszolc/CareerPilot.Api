using CareerPilot.Domain.Enums;

namespace CareerPilot.Domain.Entities;

public class JobAd
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Location { get; set; }
    public string Company { get; set; } = string.Empty;
    public ApplicationStatus Status { get; set; } = ApplicationStatus.NotSent;
    public DateTime? AppliedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public string? Link { get; set; }
    public JobAdStatus JobAdStatus { get; set; } = JobAdStatus.Active;
    public ICollection<JobInterview> Interviews { get; set; } = [];
}
