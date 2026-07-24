using CareerPilot.Application.DTOs.ApplicationFile;
using CareerPilot.Application.Interfaces;
using CareerPilot.Domain.Entities;
using CareerPilot.Infrastructure.Data;

namespace CareerPilot.Infrastructure.Services;

public class ApplicationFileService : IApplicationFileService
{
    private readonly AppDbContext _context;
    private readonly string _uploadsPath;

    public ApplicationFileService(AppDbContext context)
    {
        _context = context;
        _uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
    }

    public async Task<ApplicationFile> UploadAsync(UploadApplicationFileRequest request)
    {
        if (!Directory.Exists(_uploadsPath))
        {
            Directory.CreateDirectory(_uploadsPath);
        }

        var storedFileName = $"{Guid.NewGuid()}{Path.GetExtension(request.FileName)}";
        var fullPath = Path.Combine(_uploadsPath, storedFileName);

        await using (var fileStream = new FileStream(fullPath, FileMode.Create))
        {
            await request.Content.CopyToAsync(fileStream);
        }

        var applicationFile = new ApplicationFile
        {
            FileName = request.FileName,
            FilePath = Path.Combine("uploads", storedFileName),
            ContentType = request.ContentType,
            SizeInBytes = request.Length,
            Description = request.Description,
            Type = request.Type
        };

        _context.ApplicationFiles.Add(applicationFile);
        await _context.SaveChangesAsync();

        return applicationFile;
    }
}