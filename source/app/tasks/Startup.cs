using app.tasks.startup;

namespace app.tasks
{
  public class Startup
  {
    public static void the_application()
    {
      Start.by_running_all_steps_in("starup.steps");
    }
  }
}