namespace CareerPilot.Domain.Entities;

public class EmployerMessage
{
    //przechowalnia wiadomości - bez relacji
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
    
