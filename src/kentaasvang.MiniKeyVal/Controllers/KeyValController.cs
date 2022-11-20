using Microsoft.AspNetCore.Mvc;

namespace kentaasvang.MiniKeyVal.Controllers;

[ApiController]
[Route("[controller]")]
public class KeyValController : ControllerBase
{
    private IKeyValStore _keyValStore { get; }

    public KeyValController(IKeyValStore keyValStore)
  {
        _keyValStore = keyValStore;
    }

  [HttpGet("{key}")]
  public IActionResult Get(string key)
  {
    var result = _keyValStore.Get(key);
    return Ok(result);
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
  public IActionResult Put(string key)
  {
    var result = _keyValStore.CreateOrUpdate(key);
    return Ok(result);
  }

  [HttpDelete]
  public string Delete() => throw new NotImplementedException(); 
}
