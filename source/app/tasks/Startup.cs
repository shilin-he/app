using app.tasks.startup;

namespace app.tasks
{
  public class Startup
  {
    public static void the_application()
    {
      Start.by<ConfiguringTheContainer>()
           .followed_by<ConfiguringRoutes>()
           .finish_with<ConfiguringFrontController>();
    }
  }
}
