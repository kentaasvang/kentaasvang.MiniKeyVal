namespace kentaasvang.MiniKeyVal;

public interface IKeyValStore
{
  public bool Get(string key);
  public bool Insert(string key, string value);
}

public class KeyValStore : IKeyValStore
{
  public bool Get(string key)
  {

    throw new NotImplementedException();
  }

  public bool Insert(string key, string value)
  {
    throw new NotImplementedException();
  }
}