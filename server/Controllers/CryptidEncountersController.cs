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

}
