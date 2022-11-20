namespace kentaasvang.MiniKeyVal;

public interface IKeyValStore
{
  public Record Get(string key);
  public Record CreateOrUpdate(string key);
}

public class KeyValStore : IKeyValStore
{
    public Record Get(string key)
    {
        throw new NotImplementedException();
    }

    public Record CreateOrUpdate(string key)
    {
        throw new NotImplementedException();
    }
}