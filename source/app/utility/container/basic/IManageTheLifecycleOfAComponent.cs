namespace app.utility.container.basic
{
  public interface IManageTheLifecycleOfAComponent
  {
    object apply_to(ICreateOneDependency factory);
  }
}