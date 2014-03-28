 using System;
 using app.tasks;
 using app.tasks.startup;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{   

  [Subject(typeof(StepRunner))]
  public class StepRunnerSpecs
  {
    public abstract class concern : Observes<StepRunner>
    {
        
    }

    public class when_run_a_step : concern
    {
      Establish c = () =>
      {
        type_of_the_startup_step = typeof(ConfiguringFrontController);
        config_front_controller = fake.an<IRunAStartupStep>();
        depends.on<IGetAStartupStep>(type =>
        {
          type.ShouldEqual(type_of_the_startup_step);
          return config_front_controller;
        });
      };

      Because b = () =>
        sut.run_step(type_of_the_startup_step);

      It runs_the_step = () => config_front_controller.received(x => x.run());

      static Type type_of_the_startup_step;
      static IRunAStartupStep config_front_controller;
    }
  }
}
