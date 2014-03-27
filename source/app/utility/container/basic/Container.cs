namespace app.utility.container.basic
{
  public class Container : IFetchDependencies
  {
    IFindFactoriesThatCanCreateDependencies factories;

    public Container(IFindFactoriesThatCanCreateDependencies factories)
    {
      this.factories = factories;
    }

    public Dependency an<Dependency>()
    {
      var factory = factories.get_factory_that_can_create(typeof(Dependency));
      return (Dependency)factory.create();
    }
  }
}