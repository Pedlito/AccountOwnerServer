namespace Entities.DataTransferObjects;

public class DatabaseBaseDto
{
    public required DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public required int CreateUser { get; set; }
    public int? UpdateUser { get; set; }
    public required bool IsEnable { get; set; }
}