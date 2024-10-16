using System.ComponentModel.DataAnnotations;

namespace Crosscut.SharedDomain;

public class EntityBase
{
    public int Id { get; protected set; }

    [Timestamp] public byte[] RowVersion { get; protected set; }
}