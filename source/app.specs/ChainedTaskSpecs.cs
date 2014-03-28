 using app.tasks;
 using app.utility;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;
 using IRunATask = app.utility.IRunATask;

namespace app.specs
{  
  [Subject(typeof(ChainedTask))]  
  public class ChainedTaskSpecs
  {
    public abstract class concern : Observes<IRunATask,
      ChainedTask>
    {
        
    }

   
    public class when_run : concern
    {
      Establish c = () =>
      {
        first = fake.an<IRunATask>();
        second = fake.an<IRunATask>();

        sut_factory.create_using(() => new ChainedTask(first, second));
      };

      Because b = () =>
        sut.run();

      It runs_both_tasks = () =>
      {
        first.received(x => x.run());
        second.received(x => x.run());
      };

      static IRunATask first;
      static IRunATask second;
    }
  }
}
