using System;

namespace app.utility.container.basic
{
  public class DependencyFactories : IFindFactoriesThatCanCreateDependencies
  {
    public ICreateOneDependency get_factory_that_can_create(Type dependency_type)
    {
      throw new NotImplementedException();
    }
  }
}