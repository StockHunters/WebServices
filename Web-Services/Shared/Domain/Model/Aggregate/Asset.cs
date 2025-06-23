using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace Web_Services.Shared.Domain.Model.Aggregate;

public partial class Asset: IEntityWithCreatedUpdatedDate
{
    public int Id { get;  }
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}