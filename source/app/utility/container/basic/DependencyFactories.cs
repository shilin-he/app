using System;
using System.Collections.Generic;

namespace app.utility.container.basic
{
  public class DependencyFactories : IFindFactoriesThatCanCreateDependencies
  {
    IDictionary<Type, ICreateOneDependency> factories;
    ICreateADependencyFactoryWhenItIsMissing special_case;

    public DependencyFactories(IDictionary<Type, ICreateOneDependency> factories, ICreateADependencyFactoryWhenItIsMissing special_case)
    {
      this.factories = factories;
      this.special_case = special_case;
    }

    public ICreateOneDependency get_factory_that_can_create(Type dependency_type)
    {
      if (factories.ContainsKey(dependency_type)) return factories[dependency_type];

      return special_case(dependency_type);
    }
  }
}