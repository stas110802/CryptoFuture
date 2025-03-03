namespace FutureClient.Application.Types;

public class ContractType : BaseType
{
    private ContractType(string value) : base(value)
    {
        
    }
    
    public static ContractType Perpetual { get; } = new ContractType("PERPETUAL");
    public static ContractType CurrentQuarter { get; } = new ContractType("CURRENT_QUARTER");
    public static ContractType NextQuarter { get; } = new ContractType("NEXT_QUARTER");
}