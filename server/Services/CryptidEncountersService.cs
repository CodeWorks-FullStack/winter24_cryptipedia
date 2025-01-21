


namespace cryptipedia.Services;

public class CryptidEncountersService
{
  public CryptidEncountersService(CryptidEncountersRepository repository)
  {
    _repository = repository;
  }
  private readonly CryptidEncountersRepository _repository;

}
