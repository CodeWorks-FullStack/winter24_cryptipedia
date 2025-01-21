namespace cryptipedia.Controllers;

[ApiController]
[Route("api/{controller}")]
public class CryptidEncountersController : ControllerBase
{
  public CryptidEncountersController(Auth0Provider auth0Provider, CryptidEncountersService cryptidEncountersService)
  {
    _auth0Provider = auth0Provider;
    _cryptidEncountersService = cryptidEncountersService;
  }
  private readonly Auth0Provider _auth0Provider;
  private readonly CryptidEncountersService _cryptidEncountersService;

  [Authorize]
  [HttpPost]
  public async Task<ActionResult<CryptidEncounterProfile>> CreateCryptidEncounter([FromBody] CryptidEncounter cryptidEncounterData)
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      cryptidEncounterData.AccountId = userInfo.Id;
      CryptidEncounterProfile cryptidEncounterProfile = _cryptidEncountersService.CreateCryptidEncounter(cryptidEncounterData);
      return Ok(cryptidEncounterProfile);
    }
    catch (Exception exception)
    {
      return BadRequest(exception.Message);
    }
  }

}
