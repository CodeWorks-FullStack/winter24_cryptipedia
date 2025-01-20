
namespace cryptipedia.Repositories;

public class CryptidsRepository
{
  public CryptidsRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal Cryptid CreateCryptid(Cryptid cryptidData)
  {
    string sql = @"
    INSERT INTO
    cryptids(name, description, threat_level, size, origin, img_url, discoverer_id)
    VALUES(@Name, @Description, @ThreatLevel, @Size, @Origin, @ImgUrl, @DiscovererId);

    SELECT * FROM cryptids WHERE id = LAST_INSERT_ID();";

    Cryptid cryptid = _db.Query<Cryptid>(sql, cryptidData).SingleOrDefault();
    return cryptid;
  }
}

