using CareerPilot.Domain.Enums;

namespace CareerPilot.Application.DTOs.ApplicationFile;

public record UploadApplicationFileRequest
{
    public string FileName { get; init; } = string.Empty;
    public string ContentType { get; init; } = string.Empty; //MIME type
    public long Length {get; init;}
    public required Stream Content { get; init; }
    public ApplicationFileType Type { get; init; }
    public string? Description { get; init; }
}