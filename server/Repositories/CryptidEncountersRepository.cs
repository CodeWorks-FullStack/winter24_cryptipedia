


namespace cryptipedia.Repositories;

public class CryptidEncountersRepository
{
  public CryptidEncountersRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

}

