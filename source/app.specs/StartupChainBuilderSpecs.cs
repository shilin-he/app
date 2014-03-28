using System;
using app.tasks.startup;
using app.utility;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(StartupChainBuilder))]
  public class StartupChainBuilderSpecs
  {
    public abstract class concern : Observes<IDefineStartupChains, StartupChainBuilder>
    {
    }

    public class when_specifying_a_follow_up_step : concern
    {
      public class StepB : IRunAStartupStep
      {
        public void run()
        {
          throw new NotImplementedException();
        }
      }

      Establish c = () =>
      {
        first_step = depends.on<IRunATask>();
        step_factory = depends.on<ICreateAStartupStep>();

        combined_step = fake.an<IRunATask>();
        second_step = fake.an<IRunAStartupStep>();
        ICombineStartupSteps combinator = (x, y) =>
        {
          x.ShouldEqual(first_step);
          y.ShouldEqual(second_step);
          return combined_step;
        };
        spec.change(() => StartupChainBuilder.combine_steps).to(combinator);
        step_factory.setup(x => x.create_step(typeof(StepB)))
          .Return(second_step);
      };

      Because b = () =>
        result = sut.followed_by<StepB>();

      It returns_a_new_chain_builder_initialized_with_the_combination_of_the_new_and_previous_steps = () =>
      {
        var new_builder = result.ShouldBeAn<StartupChainBuilder>();
        new_builder.ShouldNotEqual(sut);
        new_builder.step.ShouldEqual(combined_step);
      };

      static ICreateAStartupStep step_factory;
      static IDefineStartupChains result;
      static IRunATask combined_step;
      static IRunATask first_step;
      static IRunAStartupStep second_step;
    }

    public class when_finishing_the_chain : concern
    {
      public class StepB : IRunAStartupStep
      {
        public void run()
        {
          throw new NotImplementedException();
        }
      }

      Establish c = () =>
      {
        first_step = depends.on<IRunATask>();
        step_factory = depends.on<ICreateAStartupStep>();

        combined_step = fake.an<IRunATask>();
        second_step = fake.an<IRunATask>();
        ICombineStartupSteps combinator = (x, y) =>
        {
          x.ShouldEqual(first_step);
          y.ShouldEqual(second_step);
          return combined_step;
        };
        spec.change(() => StartupChainBuilder.combine_steps).to(combinator);
        step_factory.setup(x => x.create_step(typeof(StepB)))
          .Return(second_step);
      };

      Because b = () =>
        sut.finish_with<StepB>();

      It runs_the_combined_step = () =>
        combined_step.received(x => x.run());

      static ICreateAStartupStep step_factory;
      static IRunATask combined_step;
      static IRunATask first_step;
      static IRunATask second_step;
    }
  }
}