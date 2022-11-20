namespace kentaasvang.MiniKeyVal;

public class Record
{
  public required string[] Volumes { get; set; } 
  public DeletedEnum Deleted { get;  set; }
  // public string Hash { get; set; }
}