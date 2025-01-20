


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

    SELECT
    cryptids.*,
    accounts.*
    FROM cryptids
    JOIN accounts ON cryptids.discoverer_id = accounts.id
    WHERE cryptids.id = LAST_INSERT_ID();";

    Cryptid cryptid = _db.Query(sql, (Cryptid cryptid, Profile account) =>
    {
      cryptid.Discoverer = account;
      return cryptid;
    }, cryptidData).SingleOrDefault();
    return cryptid;
  }

  internal List<Cryptid> GetAllCryptids()
  {
    string sql = @"
    SELECT
    cryptids.*,
    accounts.*
    FROM cryptids
    JOIN accounts ON cryptids.discoverer_id = accounts.id
    ORDER BY cryptids.created_at ASC;";

    List<Cryptid> cryptids = _db.Query(sql, (Cryptid cryptid, Profile account) =>
    {
      cryptid.Discoverer = account;
      return cryptid;
    }).ToList();

    return cryptids;
  }

  internal Cryptid GetCryptidById(int cryptidId)
  {
    string sql = @"
    SELECT
    cryptids.*,
    accounts.*
    FROM cryptids
    JOIN accounts ON cryptids.discoverer_id = accounts.id
    WHERE cryptids.id = @cryptidId;";

    Cryptid cryptid = _db.Query(sql, (Cryptid cryptid, Profile account) =>
    {
      cryptid.Discoverer = account;
      return cryptid;
    }, new { cryptidId }).SingleOrDefault();

    return cryptid;
  }
}

