using CareerPilot.Application.Common;
using CareerPilot.Application.DTOs.ApplicationFile;
using FluentValidation;

namespace CareerPilot.Application.Validators.JobAd;

public class UploadApplicationFileRequestValidator : AbstractValidator<UploadApplicationFileRequest>
{
    public UploadApplicationFileRequestValidator()
    {
        RuleFor(x => x.FileName)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MaximumLength(255);
        
        RuleFor(x => x.ContentType)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must((request, contentType) => 
                FileUploadRules.IsAllowed(request.FileName, contentType))
            .WithMessage("Dozwolone są tylko pliki PDF, DOC i DOCX");
        
        RuleFor(x => x.Content)
            .NotNull();
        RuleFor(x => x.Type).IsInEnum();

        RuleFor(x => x.Length)
            .GreaterThan(0)
            .LessThanOrEqualTo(FileUploadRules.MaxSizeInBytes);

        RuleFor(x => x.Description)
            .MaximumLength(500);

    }
}