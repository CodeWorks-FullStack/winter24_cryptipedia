namespace cryptipedia.Models;

// abstract denotes that this class can never be instantiated, only inherited from
// <T> represents that RepoItem will be supplied a Type argument when it is inherited from
public abstract class RepoItem<T>
{
  // we can use the Type from T for our Id
  public T Id { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}