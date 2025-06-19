using Org.BouncyCastle.Utilities;

namespace Web_Services.ClientManagement.Domain.Model.ValueObjects;

public record SaleQuantity(int Quantity)
{
    public SaleQuantity() : this(1){}
}