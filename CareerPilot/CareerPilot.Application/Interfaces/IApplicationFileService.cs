using CareerPilot.Application.DTOs.ApplicationFile;
using CareerPilot.Domain.Entities;

namespace CareerPilot.Application.Interfaces;

public interface IApplicationFileService
{
    Task<ApplicationFile> UploadAsync(UploadApplicationFileRequest request);
}