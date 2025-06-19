namespace Web_Services.ClientManagement.Domain.Model.ValueObjects;

public record SaleStatus(bool Status)
{
    public SaleStatus() : this(false){}
}