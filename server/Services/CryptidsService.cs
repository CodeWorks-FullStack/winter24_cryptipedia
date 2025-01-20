namespace cryptipedia.Services;

public class CryptidsService
{
  public CryptidsService(CryptidsRepository repository)
  {
    _repository = repository;
  }
  private readonly CryptidsRepository _repository;

}
