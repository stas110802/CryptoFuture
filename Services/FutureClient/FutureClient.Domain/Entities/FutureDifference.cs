namespace FutureClient.Domain.Entities;

public class FutureDifference
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string Currency { get; set; } = string.Empty;
    public decimal CurrentQuarterPrice { get; set; } 
    public decimal NextQuarterPrice { get; set; }
    public decimal Difference => CurrentQuarterPrice - NextQuarterPrice;
}