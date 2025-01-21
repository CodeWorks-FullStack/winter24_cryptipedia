





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

  private CryptidEncounter GetCryptidEncounterById(int cryptidEncounterId)
  {
    CryptidEncounter cryptidEncounter = _repository.GetCryptidEncounterById(cryptidEncounterId);

    if (cryptidEncounter == null) throw new Exception($"Invalid cryptid encounter id: {cryptidEncounterId}");

    return cryptidEncounter;
  }

  internal string DeleteCryptidEncounter(int cryptidEncounterId, string userId)
  {
    CryptidEncounter cryptidEncounter = GetCryptidEncounterById(cryptidEncounterId);

    if (cryptidEncounter.AccountId != userId) throw new Exception("YOU CAN NOT REMOVE A CRYPTID ENCOUNTER THAT YOU DID NOT CREATE");

    _repository.DeleteCryptidEncounter(cryptidEncounterId);

    return "NO LONGER ENCOUNTERED THAT CRYPTID";
  }
}
