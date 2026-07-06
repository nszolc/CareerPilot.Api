using CareerPilot.Application.DTOs.JobAd;
using FluentValidation;

namespace CareerPilot.Application.Validators.JobAd;

public class UpdateJobAdRequestValidator : AbstractValidator<UpdateJobAdRequest>
{
    public UpdateJobAdRequestValidator()
    {
        RuleFor(x => x.Title)
            .MaximumLength(150)
            .When(x => x.Title is not null);

        RuleFor(x => x.Company)
            .MaximumLength(120)
            .When(x => x.Company is not null);

        RuleFor(x => x.Link)
            .Must(link => Uri.TryCreate(link, UriKind.Absolute, out _))
            .When(x => !string.IsNullOrWhiteSpace(x.Link));

        RuleFor(x => x)
            .Must(x =>
                x.Title is not null ||
                x.Description is not null ||
                x.Location is not null ||
                x.Company is not null ||
                x.Status is not null ||
                x.AppliedAt is not null ||
                x.Link is not null)
            .WithMessage("At least one field must be provided.");
    }
}
