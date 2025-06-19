namespace Web_Services.ClientManagement.Domain.Model.ValueObjects;

public record SaleDate(DateTime Date)
{
    public SaleDate() : this(DateTime.Now){}
}