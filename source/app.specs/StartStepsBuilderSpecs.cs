using System;
using System.Collections.Generic;
using app.tasks;
using app.tasks.startup;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(StartStepsBuilder))]
  public class StartStepsBuilderSpecs
  {
    public abstract class concern : Observes<IBuildStartSteps, StartStepsBuilder>
    {
    }

    public class when_build : concern
    {
      static IList<Type> result;

      Because b = () =>
      {
        sut.followed_by<ConfiguringTheContainer>();
        sut.followed_by<ConfiguringRoutes>();
        result = new List<Type>(sut.get_steps());
      };

      It saves_the_steps = () =>
      {
        result.Count.ShouldEqual(2);
        result[0].ShouldEqual(typeof(ConfiguringTheContainer));
        result[1].ShouldEqual(typeof(ConfiguringRoutes));
      };
    }

    public class when_finish_building : concern
    {
      static IRunSteps step_runner;
      static Type step_type;
      static IList<Type> result;

      Because b = () =>
      {
        sut.followed_by<ConfiguringTheContainer>();
        sut.finish_with<ConfiguringFrontController>();
        result = new List<Type>(sut.get_steps());
      };

      Establish c = () =>
      {
        step_type = typeof(ConfiguringFrontController);
        step_runner = depends.on<IRunSteps>();
      };

      It runs_all_steps = () => step_runner.received(x => x.run_step(step_type)).Times(2);

      It saves_the_step = () =>
        result.ShouldContain(step_type);
    }
  }
}