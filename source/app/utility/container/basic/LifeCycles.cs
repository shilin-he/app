namespace app.utility.container.basic
{
  public class LifeCycles
  {
    public static readonly IManageTheLifecycleOfAComponent Singleton = new SingletonLifeCycle();
    public static readonly IManageTheLifecycleOfAComponent Regular = new RegularLifeCycle();
  }
}