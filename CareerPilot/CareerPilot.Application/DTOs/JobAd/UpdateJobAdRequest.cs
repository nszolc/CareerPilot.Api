using CareerPilot.Domain.Enums;

namespace CareerPilot.Application.DTOs.JobAd;

public record UpdateJobAdRequest
{
    public string? Title { get; init; }
    public string? Description { get; init; }
    public string? Location { get; init; }
    public string? Company { get; init; }
    public ApplicationStatus? Status { get; init; } 
    public DateTime? AppliedAt { get; init; }
    public string? Link { get; init; }
}