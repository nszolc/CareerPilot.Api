namespace CareerPilot.Domain.Entities;

public class JobInterview
{
    public int Id { get; set; }
    public int JobAdId { get; set; }
    public JobAd JobAd { get; set; } = null!;
    public string? Link { get; set; }
    public DateTime Date { get; set; }
    public string? Notes { get; set; }
    public string? Feedback { get; set; }
}
