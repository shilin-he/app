using System;

namespace app.utility.container.basic
{
  public class Container : IFetchDependencies
  {
    IFindFactoriesThatCanCreateDependencies factories;
    ICreateDependencyCreationErrors error_factory;

    public Container(IFindFactoriesThatCanCreateDependencies factories, ICreateDependencyCreationErrors error_factory)
    {
      this.factories = factories;
      this.error_factory = error_factory;
    }

    public Dependency an<Dependency>()
    {
      /* SyntaxSugar.blocks.run(() => */
      /* { */
      /*   var factory = factories.get_factory_that_can_create(typeof(Dependency)); */
      /*   return (Dependency)factory.create(); */
      /* }) */
      /* .on_error(e => throw error_factory(typeof(Dependency), e))() */
      /* ; */
      try
      {
        var factory = factories.get_factory_that_can_create(typeof(Dependency));
        return (Dependency)factory.create();
      }
      catch (Exception e)
      {
        throw error_factory(typeof(Dependency), e);
      }
    }
  }
}
