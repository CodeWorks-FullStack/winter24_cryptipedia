



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
}

