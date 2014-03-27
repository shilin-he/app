namespace app.utility.container.basic
{
  public class Container : IFetchDependencies
  {
    ICreateDependencies dependency_factory;

    public Container(ICreateDependencies dependency_factory)
    {
      this.dependency_factory = dependency_factory;
    }

    public Dependency an<Dependency>()
    {
      return dependency_factory.create<Dependency>();
    }
  }
}