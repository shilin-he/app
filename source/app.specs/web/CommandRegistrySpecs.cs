 using System.Collections.Generic;
 using System.Linq;
 using app.web.core;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs.web
{  
  [Subject(typeof(CommandRegistry))]  
  public class CommandRegistrySpecs
  {
    public abstract class concern : Observes<IFindCommandsToProcessRequests,
      CommandRegistry>
    {
        
    }

    public class when_getting_a_command_to_process_a_request : concern
    {
      public class and_it_has_the_command
      {
        Establish c = () =>
        {
          all_commands = Enumerable.Range(1, 100).Select(x => fake.an<IProcessOneRequest>()).ToList();
          request = fake.an<IProvideDetailsAboutARequest>();
          the_command_that_can_process_the_request = fake.an<IProcessOneRequest>();
          all_commands.Add(the_command_that_can_process_the_request);

          the_command_that_can_process_the_request.setup(x => x.can_process(request))
            .Return(true);

          depends.on<IEnumerable<IProcessOneRequest>>(all_commands);
        };

        Because b = () =>
          result = sut.get_command_that_can_process(request);

        It returns_the_command_to_the_caller = () =>
          result.ShouldEqual(the_command_that_can_process_the_request);

        static IProcessOneRequest result;
        static IProcessOneRequest the_command_that_can_process_the_request;
        static IProvideDetailsAboutARequest request;
        static IList<IProcessOneRequest> all_commands;
      }
      public class and_it_does_not_have_the_command 
      {
        Establish c = () =>
        {
          all_commands = Enumerable.Range(1, 100).Select(x => fake.an<IProcessOneRequest>()).ToList();
          special_case = fake.an<IProcessOneRequest>();
          request = fake.an<IProvideDetailsAboutARequest>();
          depends.on<IEnumerable<IProcessOneRequest>>(all_commands);
          depends.on<ICreateASpecialCaseWhenACommandIsNotFound>(x =>
          {
            x.ShouldEqual(request);
            return special_case;
          });
        };

        Because b = () =>
          result = sut.get_command_that_can_process(request);

        It return_the_result_of_running_the_special_case_handler = () =>
          result.ShouldEqual(special_case);

        static IProcessOneRequest result;
        static IProcessOneRequest special_case;
        static IProvideDetailsAboutARequest request;
        static IList<IProcessOneRequest> all_commands;
      }
    }
  }
}
