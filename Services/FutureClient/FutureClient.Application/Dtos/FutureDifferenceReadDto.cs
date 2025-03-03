namespace FutureClient.Application.Dtos;

public class FutureDifferenceReadDto
{
    public string Currency { get; set; } = string.Empty;
    public decimal Difference { get; set; }
}