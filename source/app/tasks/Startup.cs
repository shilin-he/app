using app.tasks.startup;
using app.tasks.startup.steps;

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
