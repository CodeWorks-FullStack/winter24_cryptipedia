namespace cryptipedia.Models;

// abstract denotes that this class can never be instantiated, only inherited from
public abstract class RepoItem
{
  public int Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}