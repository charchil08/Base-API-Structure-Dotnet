using System.ComponentModel.DataAnnotations.Schema;
using EAL.DataModels;

namespace EAL.DataModels;
public class TimestampedEntity<T> : IdentityEntity<T>
{
    [Column("created_on")]
    public DateTimeOffset CreatedOn { get; set; }

    [Column("modified_on")]
    public DateTimeOffset ModifiedOn { get; set; }
}