using System;

namespace app.utility.container.basic
{
  public class Container : IFetchDependencies
  {

    public Container(ICreateDependencies dependency_factory)
    {

    }

    public Dependency an<Dependency>()
    {
      throw new NotImplementedException();
    }
  }
}