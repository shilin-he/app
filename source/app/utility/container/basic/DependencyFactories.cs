using System;
using System.Collections;
using System.Collections.Generic;

namespace app.utility.container.basic
{
  public class DependencyFactories : IFindFactoriesThatCanCreateDependencies
  {
    IDictionary<Type, ICreateOneDependency> factories;

    public DependencyFactories(IDictionary<Type, ICreateOneDependency> factories)
    {
      this.factories = factories;
    }

    public ICreateOneDependency get_factory_that_can_create(Type dependency_type)
    {
      return factories[dependency_type];
    }
  }
}