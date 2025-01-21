namespace cryptipedia.Models;

public class CryptidEncounter : RepoItem<int>
{
  public string AccountId { get; set; }
  public int CryptidId { get; set; }
}

public class CryptidEncounterProfile : Profile
{
  public int CryptidEncounterId { get; set; }
  public int CryptidId { get; set; }
}