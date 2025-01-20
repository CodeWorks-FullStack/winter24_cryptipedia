namespace cryptipedia.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CryptidsController : ControllerBase
{
  public CryptidsController(CryptidsService cryptidsService)
  {
    _cryptidsService = cryptidsService;
  }
  private readonly CryptidsService _cryptidsService;

}
