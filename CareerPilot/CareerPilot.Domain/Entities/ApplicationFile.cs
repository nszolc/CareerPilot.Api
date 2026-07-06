using CareerPilot.Domain.Enums;

namespace CareerPilot.Domain.Entities;

public class ApplicationFile
{
    //przechowalnia plików - bez relacji
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public string? ContentType { get; set; }
    public long? SizeInBytes { get; set; }
    public string? Description { get; set; }
    public ApplicationFileType Type { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    
}
