using System;
using System.Collections.Generic;
using app.tasks;
using app.tasks.startup;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(Start))]
  public class StartSpecs
  {
    public abstract class concern : Observes<Start>
    {
    }

    public class when_beginning_the_definition_of_a_startup_pipeline : concern
    {
      Establish c = () =>
      {
        startup_step_builder = fake.an<IDefineStartupChains>();
        ICreateAStartupChainFromAnInitialStep factory = (type) =>
        {
          type.ShouldEqual(typeof(MyCustomStep));
          return startup_step_builder;
        };
        spec.change(() => Start.create_chain).to(factory);
      };

      Because b = () =>
        result = Start.by<MyCustomStep>();

      It creates_a_startup_step_builder_using_the_initial_startup_step = () =>
        result.ShouldEqual(startup_step_builder);

      static IDefineStartupChains startup_step_builder;
      static IDefineStartupChains result;
    }

    public class MyCustomStep : IRunAStartupStep
    {
      public void run()
      {
        throw new NotImplementedException();
      }
    }
  }
}