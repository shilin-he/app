namespace app.utility.container.basic
{
  public class RegularLifeCycle : IManageTheLifecycleOfAComponent
  {
    public object apply_to(ICreateOneDependency factory)
    {
      return factory.create();
    }
  }
}