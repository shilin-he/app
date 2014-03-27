namespace app.utility.container.basic
{
  public class SingletonLifeCycle : IManageTheLifecycleOfAComponent
  {
    object instance;

    public object apply_to(ICreateOneDependency factory)
    {
      return instance ?? (instance = factory.create());
    }
  }
}