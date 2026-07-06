using CareerPilot.Application.DTOs.JobAd;
using CareerPilot.Domain.Enums;
using FluentValidation;

namespace CareerPilot.Application.Validators.JobAd;

public class ChangeApplicationStatusRequestValidator : AbstractValidator<ChangeApplicationStatusRequest>
{
    public ChangeApplicationStatusRequestValidator()
    {
        RuleFor(x => x.Status).IsInEnum();

        RuleFor(x => x.AppliedAt)
            .NotNull()
            .When(x => x.Status == ApplicationStatus.Sent)
            .WithMessage("AppliedAt is required when application status is Sent.");
    }
}
