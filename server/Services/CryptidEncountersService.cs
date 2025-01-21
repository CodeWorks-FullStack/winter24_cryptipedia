




namespace cryptipedia.Services;

public class CryptidEncountersService
{
  public CryptidEncountersService(CryptidEncountersRepository repository)
  {
    _repository = repository;
  }
  private readonly CryptidEncountersRepository _repository;

  internal CryptidEncounterProfile CreateCryptidEncounter(CryptidEncounter cryptidEncounterData)
  {
    CryptidEncounterProfile cryptidEncounterProfile = _repository.CreateCryptidEncounter(cryptidEncounterData);
    return cryptidEncounterProfile;
  }

  internal List<CryptidEncounterProfile> GetCryptidEncounterProfilesByCryptidId(int cryptidId)
  {
    List<CryptidEncounterProfile> cryptidEncounterProfiles = _repository.GetCryptidEncounterProfilesByCryptidId(cryptidId);
    return cryptidEncounterProfiles;
  }
}
