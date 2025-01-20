

namespace cryptipedia.Services;

public class CryptidsService
{
  public CryptidsService(CryptidsRepository repository)
  {
    _repository = repository;
  }
  private readonly CryptidsRepository _repository;

  internal Cryptid CreateCryptid(Cryptid cryptidData)
  {
    Cryptid cryptid = _repository.CreateCryptid(cryptidData);
    return cryptid;
  }

  internal List<Cryptid> GetAllCryptids()
  {
    List<Cryptid> cryptids = _repository.GetAllCryptids();
    return cryptids;
  }

}
