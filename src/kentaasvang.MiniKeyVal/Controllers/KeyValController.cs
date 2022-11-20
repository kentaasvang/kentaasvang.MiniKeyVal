using Microsoft.AspNetCore.Mvc;

namespace kentaasvang.MiniKeyVal.Controllers;

[ApiController]
[Route("[controller]")]
public class KeyValController : ControllerBase
{
    private ILogger<KeyValController> _logger { get; }
    private IKeyValStore _keyValStore { get; }

  public KeyValController(ILogger<KeyValController> logger, IKeyValStore keyValStore)
  {
        _logger = logger;
        _keyValStore = keyValStore;
  }

  [HttpGet("{key}")]
  public IActionResult Get([FromBody] string value, string key)
  {
    _logger.LogInformation($"Inserting value: {value} with key: {key}");
    var result = _keyValStore.Get(key);
    return Ok();
  }

  [HttpHead]
  public string Head()
  {
    throw new NotImplementedException();
  }

  [HttpPost]
  public string Post()
  {
    throw new NotImplementedException();
  }

  [HttpPut("{key}")]
  public IActionResult Put([FromBody] string value, string key)
  {
    var result = _keyValStore.InsertOrUpdate(key, value);

    return result
      ? Ok()
      : Conflict();
  }

  [HttpDelete]
  public string Delete() => throw new NotImplementedException(); 
}
