namespace app.utility.container.basic
{
  public interface ICreateDependencies
  {
    Dependency create<Dependency>();
  }
}