using System;

namespace app.utility.container
{
  public class Fetch
  {
    public static IResolveTheInitialContainer container_resolution = () =>
    {
      throw new NotImplementedException("Container resolution needs to be configured by a startup pipeline"); 
    };

    public static IFetchDependencies me
    {
      get
      {
        return container_resolution();
      }
    }
  }
}