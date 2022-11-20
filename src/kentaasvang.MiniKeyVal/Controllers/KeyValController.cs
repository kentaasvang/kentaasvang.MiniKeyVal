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
  public IActionResult Get(string key)
  {
    _logger.LogInformation("Trying to retrieve value on key: {key}");
    var result = _keyValStore.Get(key);

    return result
      ? Redirect("url")
      : NotFound();
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
    _logger.LogInformation($"Trying to insert value: {value} on key: {key}");
    var result = _keyValStore.Insert(key, value);

    return result
      ? Ok()
      : Conflict();
  }

  [HttpDelete]
  public string Delete() => throw new NotImplementedException(); 
}
