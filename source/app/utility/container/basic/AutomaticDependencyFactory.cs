using System;
using System.Linq;

namespace app.utility.container.basic
{
  public class AutomaticDependencyFactory : ICreateOneDependency
  {
    public IFetchDependencies container;
    public IGetTheConstructorToCreateAType constructor_selection_strategy;
    public Type type_to_create;

    public AutomaticDependencyFactory(IFetchDependencies container, IGetTheConstructorToCreateAType constructor_selection_strategy, Type type_to_create)
    {
      this.container = container;
      this.constructor_selection_strategy = constructor_selection_strategy;
      this.type_to_create = type_to_create;
    }

    public object create()
    {
      var ctor = constructor_selection_strategy(type_to_create);
      var ctor_parameters = ctor.GetParameters().Select(x => container.an(x.ParameterType));
      return ctor.Invoke(ctor_parameters.ToArray());
    }
  }
}