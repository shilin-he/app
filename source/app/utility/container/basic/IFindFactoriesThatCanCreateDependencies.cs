using System;

namespace app.utility.container.basic
{
  public interface IFindFactoriesThatCanCreateDependencies
  {
    ICreateOneDependency get_factory_that_can_create(Type dependency_type);
  }
}