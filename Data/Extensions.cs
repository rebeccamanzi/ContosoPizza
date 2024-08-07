namespace ContosoPizza.Data;

public static class Extensions
{
  public static void CreateDbIfNotExists(this IHost host)
  {
    {
      using (var scope = host.Services.CreateScope())
      {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<PizzaContext>();
        context.Database.EnsureCreated();
        DbInitializer.Initialize(context);
      }
    }
  }
}

// If a database doesn't exist, EnsureCreated creates a new database. The new database isn't configured for migrations, so use this method with caution.