namespace cryptipedia.Controllers;

[ApiController]
[Route("api/{controller}")]
public class CryptidsController : ControllerBase
{
  public CryptidsController(CryptidsService cryptidsService, Auth0Provider auth0Provider, CryptidEncountersService cryptidEncountersService)
  {
    _cryptidsService = cryptidsService;
    _auth0Provider = auth0Provider;
    _cryptidEncountersService = cryptidEncountersService;
  }
  private readonly CryptidsService _cryptidsService;
  private readonly CryptidEncountersService _cryptidEncountersService;
  private readonly Auth0Provider _auth0Provider;

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<Cryptid>> CreateCryptid([FromBody] Cryptid cryptidData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      cryptidData.DiscovererId = userInfo.Id;
      Cryptid cryptid = _cryptidsService.CreateCryptid(cryptidData);
      return Ok(cryptid);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Cryptid>> GetAllCryptids()
  {
    try
    {
      List<Cryptid> cryptids = _cryptidsService.GetAllCryptids();
      return Ok(cryptids);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{cryptidId}")]
  public ActionResult<Cryptid> GetCryptidById(int cryptidId)
  {
    try
    {
      Cryptid cryptid = _cryptidsService.GetCryptidById(cryptidId);
      return Ok(cryptid);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

  [HttpGet("{cryptidId}/cryptidEncounters")]
  public ActionResult<List<CryptidEncounterProfile>> GetCryptidEncounterProfilesByCryptidId(int cryptidId)
  {
    try
    {
      List<CryptidEncounterProfile> cryptidEncounterProfiles = _cryptidEncountersService.GetCryptidEncounterProfilesByCryptidId(cryptidId);
      return Ok(cryptidEncounterProfiles);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }
}
