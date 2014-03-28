using System;
using System.Collections.Generic;
using System.Linq;
using app.utility;
using app.utility.container;
using app.utility.container.basic;
using app.web.core;

namespace app.tasks.startup
{
  public class StartupItems
  {
    public class Tasks
    {
      public static readonly ICombineStartupSteps combine = TaskExtensions.combine_with;
    }

    public class Reflection
    {
      public static readonly IGetTheConstructorToCreateAType greediest_ctor = (type) =>
        type.GetConstructors().OrderByDescending(x => x.GetParameters().Count()).First();

      public class create<ReturnType>
      {
        public static ReturnType create_instance(Type type, params object[] args)
        {
          return (ReturnType) Activator.CreateInstance(type, args);
        }
      }
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
        throw new NotImplementedException(string.Format("There was an error creating a {0}", type.Name), error);
      };

      public static ICreateASpecialCaseWhenACommandIsNotFound command_not_found_for_request = (request) =>
      {
        throw new NotImplementedException("There is no command configured for the request");
      };
    }

    public class Containers
    {
      public class Basic
      {
        class LazyServices : IProvideStartupServices
        {
          IProvideStartupServices real
          {
            get
            {
              return Fetch.me.an<IProvideStartupServices>();
            }
          }

          public void register<Contract, Implementation>() where Implementation : Contract
          {
            real.register<Contract, Implementation>();
          }

          public void register<Contract>(Contract instance)
          {
            real.register(instance);
          }

          public void register<Implementation>()
          {
            real.register<Implementation>();
          }

          public IFetchDependencies container
          {
            get { return real.container; }
          }
        }
        public static ICreateAStartupChainFromAnInitialStep create_chain = (type) =>
        {
          var step_factory = new StartupStepFactory(new LazyServices());
          var first_step = step_factory.create_step(type);
          return new StartupChainBuilder(first_step, step_factory);
        };
      }
    }
  }
}