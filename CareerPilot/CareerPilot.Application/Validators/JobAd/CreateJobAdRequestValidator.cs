using CareerPilot.Application.DTOs.JobAd;
using FluentValidation;

namespace CareerPilot.Application.Validators.JobAd;

public class CreateJobAdRequestValidator : AbstractValidator<CreateJobAdRequest>
{
    public CreateJobAdRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.Company)
            .NotEmpty()
            .MaximumLength(120);

        RuleFor(x => x.Status).IsInEnum();

        RuleFor(x => x.Link)
            .Must(link => Uri.TryCreate(link, UriKind.Absolute, out _))
            .When(x => !string.IsNullOrWhiteSpace(x.Link));
    }
}
