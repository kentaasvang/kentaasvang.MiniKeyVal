namespace kentaasvang.MiniKeyVal;

public static class DependencyInjectionExtensions
{
  public static IServiceCollection AddKeyValStore(this IServiceCollection services)
  {
    services.AddTransient<IKeyValStore, KeyValStore>();
    return services;
  }
}