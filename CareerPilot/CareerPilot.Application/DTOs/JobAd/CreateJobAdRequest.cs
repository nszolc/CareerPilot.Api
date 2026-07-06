using CareerPilot.Domain.Enums;

namespace CareerPilot.Application.DTOs.JobAd;

public record CreateJobAdRequest
{
    public string Title { get; init; } = string.Empty;
    public string? Description { get; init; }
    public string? Location { get; init; }
    public string Company { get; init; } = string.Empty;
    public ApplicationStatus Status { get; init; } = ApplicationStatus.NotSent;
    public DateTime? AppliedAt { get; init; }
    public DateTime CreatedAt { get; init; }
    public string? Link { get; init; }
}