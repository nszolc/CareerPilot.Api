namespace CareerPilot.Application.Common;

public static class FileUploadRules
{
    public const long MaxSizeInBytes = 5 * 1024 * 1024;

    private static readonly Dictionary<string, string[]> AllowedTypes =
        new(StringComparer.OrdinalIgnoreCase)
        {
            [".pdf"] = [ "application/pdf" ],
            [".doc"] = ["application/msword"],
            [".docx"] = ["application/vnd.openxmlformats-officedocument.wordprocessingml.document"]
        };

    public static string GetExtension(string fileName) =>
        Path.GetExtension(Path.GetFileName(fileName));

    public static bool IsAllowed(string fileName, string contentType)
    {
        if (string.IsNullOrWhiteSpace(fileName) || string.IsNullOrWhiteSpace(contentType))
            return false;

        var extension = GetExtension(fileName);

        if (!AllowedTypes.TryGetValue(extension, out var allowedMimeTypes))
            return false;

        return allowedMimeTypes.Contains(contentType.Trim(), StringComparer.OrdinalIgnoreCase);
    }
}