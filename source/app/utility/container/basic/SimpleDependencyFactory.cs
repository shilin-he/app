using System;

namespace app.utility.container.basic
{
  public class SimpleDependencyFactory : ICreateOneDependency
  {
    Func<object> factory;

    public SimpleDependencyFactory(Func<object> factory)
    {
      this.factory = factory;
    }

    public object create()
    {
      return factory();
    }
  }
}