using app.tasks.startup;
using app.tasks.startup.steps;

namespace app.tasks
{
  public class StartApplication
  {
    public static void run()
    {
      Start.by<ConfiguringTheContainer>()
           .followed_by<ConfiguringFrontController>()
           .finish_with<ConfiguringRoutes>();
    }
  }
}