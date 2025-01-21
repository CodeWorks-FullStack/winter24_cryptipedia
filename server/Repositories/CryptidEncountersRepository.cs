namespace cryptipedia.Repositories;

public class CryptidEncountersRepository
{
  public CryptidEncountersRepository(IDbConnection db)
  {
    _db = db;
  }
  private readonly IDbConnection _db;

  internal CryptidEncounterProfile CreateCryptidEncounter(CryptidEncounter cryptidEncounterData)
  {
    // NOTE must have set up view in dbSetup for this to work
    string sql = @"
    INSERT INTO
    cryptid_encounters(account_id, cryptid_id)
    VALUES(@AccountId, @CryptidId);

    SELECT * FROM cryptid_encounter_profiles_view
    WHERE cryptid_encounter_profiles_view.cryptid_encounter_id = LAST_INSERT_ID();";

    CryptidEncounterProfile cryptidEncounterProfile = _db.Query<CryptidEncounterProfile>(sql, cryptidEncounterData).SingleOrDefault();

    return cryptidEncounterProfile;
  }

  // REVIEW another way of writing CreateCryptidEncounter
  private CryptidEncounterProfile CreateCryptidEncounterWithVirtualColumns(CryptidEncounter cryptidEncounterData)
  {
    string sql = @"
    INSERT INTO
    cryptid_encounters(account_id, cryptid_id)
    VALUES(@AccountId, @CryptidId);

    SELECT 
    accounts.*,
    cryptid_encounters.id AS cryptid_encounter_id
    FROM cryptid_encounters
    JOIN accounts ON accounts.id = cryptid_encounters.account_id
    WHERE cryptid_encounters.id = LAST_INSERT_ID();";

    CryptidEncounterProfile cryptidEncounterProfile = _db.Query<CryptidEncounterProfile>(sql, cryptidEncounterData).SingleOrDefault();

    return cryptidEncounterProfile;
  }

  // REVIEW another way of writing CreateCryptidEncounter
  private CryptidEncounterProfile CreateCryptidEncounterWithoutVirtualColumns(CryptidEncounter cryptidEncounterData)
  {
    string sql = @"
    INSERT INTO
    cryptid_encounters(account_id, cryptid_id)
    VALUES(@AccountId, @CryptidId);

    SELECT
    cryptid_encounters.*,
    accounts.*
    FROM cryptid_encounters
    JOIN accounts ON accounts.id = cryptid_encounters.account_id
    WHERE cryptid_encounters.id = LAST_INSERT_ID();";

    CryptidEncounterProfile cryptidEncounterProfile = _db.Query(sql, (CryptidEncounter cryptidEncounter, CryptidEncounterProfile account) =>
    {
      account.CryptidEncounterId = cryptidEncounter.Id;
      return account;
    }, cryptidEncounterData).SingleOrDefault();

    return cryptidEncounterProfile;
  }

  internal List<CryptidEncounterProfile> GetCryptidEncounterProfilesByCryptidId(int cryptidId)
  {
    // NOTE must have set up view in dbSetup for this to work
    string sql = "SELECT * FROM cryptid_encounter_profiles_view WHERE cryptid_id = @cryptidId;";

    List<CryptidEncounterProfile> cryptidEncounterProfiles = _db.Query<CryptidEncounterProfile>(sql, new { cryptidId }).ToList();

    return cryptidEncounterProfiles;
  }

  // REVIEW another way of writing GetCryptidEncounterProfilesByCryptidId
  internal List<CryptidEncounterProfile> GetCryptidEncounterProfilesWithVirtualColumns(int cryptidId)
  {
    string sql = @"
    SELECT
    accounts.*,
    cryptid_encounters.id AS cryptid_encounter_id,
    cryptid_encounters.cryptid_id AS cryptid_id
    FROM cryptid_encounters
    JOIN accounts ON accounts.id = cryptid_encounters.account_id
    WHERE cryptid_encounters.cryptid_id = @cryptidId;";

    List<CryptidEncounterProfile> cryptidEncounterProfiles = _db.Query<CryptidEncounterProfile>(sql, new { cryptidId }).ToList();

    return cryptidEncounterProfiles;
  }

  // REVIEW another way of writing GetCryptidEncounterProfilesByCryptidId
  internal List<CryptidEncounterProfile> GetCryptidEncounterProfilesWithoutVirtualColumns(int cryptidId)
  {
    string sql = @"
    SELECT
    cryptid_encounters.*,
    accounts.*
    FROM cryptid_encounters
    JOIN accounts ON accounts.id = cryptid_encounters.account_id
    WHERE cryptid_encounters.cryptid_id = @cryptidId;";

    List<CryptidEncounterProfile> cryptidEncounterProfiles = _db.Query(sql, (CryptidEncounter cryptidEncounter, CryptidEncounterProfile account) =>
    {
      account.CryptidEncounterId = cryptidEncounter.Id;
      return account;
    }, new { cryptidId }).ToList();

    return cryptidEncounterProfiles;
  }

  internal CryptidEncounter GetCryptidEncounterById(int cryptidEncounterId)
  {
    string sql = "SELECT * FROM cryptid_encounters WHERE id = @cryptidEncounterId;";

    CryptidEncounter cryptidEncounter = _db.Query<CryptidEncounter>(sql, new { cryptidEncounterId }).SingleOrDefault();

    return cryptidEncounter;
  }

  internal void DeleteCryptidEncounter(int cryptidEncounterId)
  {
    string sql = "DELETE FROM cryptid_encounters WHERE id = @cryptidEncounterId LIMIT 1;";

    int rowsAffected = _db.Execute(sql, new { cryptidEncounterId });

    if (rowsAffected != 1) throw new Exception($"DELETE FAILED WITH {rowsAffected} ROWS DELETED");
  }
}

