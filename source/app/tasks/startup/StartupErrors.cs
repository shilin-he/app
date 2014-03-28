using System;
using System.Linq;
using app.utility;
using app.utility.container.basic;
using app.web.core;

namespace app.tasks.startup
{
  public class StartupItems
  {
    public class tasks
    {
      public static readonly ICombineStartupSteps combine = TaskExtensions.combine_with;
    }

    public class Reflection
    {
      public static readonly IGetTheConstructorToCreateAType greediest_ctor = (type) =>
        type.GetConstructors().OrderByDescending(x => x.GetParameters().Count()).First();
    }
    public class Errors
    {
      public static ICreateADependencyFactoryWhenItIsMissing dependency_factory_missing = type_that_has_no_factory =>
      {
        throw new NotImplementedException(string.Format("There is no factory that can create a : {0}",
          type_that_has_no_factory.Name));
      };

      public static ICreateDependencyCreationErrors dependency_creation_error = (type, error) =>
      {
        throw new NotImplementedException(string.Format("There was an error creating a {0}", type.Name),error);
      };

      public static ICreateASpecialCaseWhenACommandIsNotFound command_not_found_for_request = (request) =>
      {
        throw new NotImplementedException("There is no command configured for the request");
      };
    }
  }
}