namespace kentaasvang.MiniKeyVal;

public interface IKeyValStore
{
  public Record Get(string key);
  public bool InsertOrUpdate(string key, string value);
}

public class KeyValStore : IKeyValStore
{
    public Record Get(string key)
    {
        throw new NotImplementedException();
    }

    public bool InsertOrUpdate(string key, string value)
    {
        throw new NotImplementedException();
    }
}