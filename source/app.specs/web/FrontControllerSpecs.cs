 using app.web.core;
 using Machine.Specifications;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs.web
{  
  [Subject(typeof(FrontController))]  
  public class FrontControllerSpecs
  {
    public abstract class concern : Observes<IProcessWebRequests,
      FrontController>
    {
        
    }

   
    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        command_registry = depends.on<IFindCommandsToProcessRequests>();
        request = fake.an<IProvideDetailsAboutARequest>();
        command_that_can_handle_the_request = fake.an<IProcessOneRequest>();

        command_registry.setup(x => x.get_command_that_can_process(request))
          .Return(command_that_can_handle_the_request);
      };

      Because b = () =>
        sut.process(request);

      It delegates_the_processing_to_the_command_that_can_process_the_request = () =>
        command_that_can_handle_the_request.received(x => x.process(request));

      static IProcessOneRequest command_that_can_handle_the_request;
      static IProvideDetailsAboutARequest request;
      static IFindCommandsToProcessRequests command_registry;
    }
  }
}
