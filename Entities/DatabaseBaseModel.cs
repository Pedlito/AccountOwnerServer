namespace Entities;

public class DatabaseBaseModel
{
    public int Code { get; set; }
    public required DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public required int CreateUser { get; set; }
    public int Updateuser { get; set; }
    public required bool isEnable { get; set; }
}