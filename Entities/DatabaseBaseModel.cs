using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class DatabaseBaseModel
{
    [Column("code", Order = 1)]
    public int Code { get; set; }

    [Column("create_date", TypeName = "timestamp(0)")]
    public required DateTime CreateDate { get; set; }

    [Column("update_date", TypeName = "timestamp(0)")]
    public DateTime? UpdateDate { get; set; }

    [Column("delete_date", TypeName = "timestamp(0)")]
    public DateTime? DeleteDate { get; set; }

    [Column("create_user", TypeName = "smallint")]
    public required int CreateUser { get; set; }

    [Column("update_user", TypeName = "smallint")]
    public int UpdateUser { get; set; }

    [Column("is_enable", TypeName = "bool")]
    public required bool IsEnable { get; set; }
}