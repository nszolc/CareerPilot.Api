using CareerPilot.Domain.Enums;

namespace CareerPilot.Application.DTOs.JobAd;

public record ChangeApplicationStatusRequest
{
    public ApplicationStatus Status { get; init; }
    public DateTime? AppliedAt { get; init; }
}