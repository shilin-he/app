using System;
using app.utility;

namespace app.tasks
{
    public class StepFactory : ICreateAStartupStep
    {
        private IProvideStartupServices startupServices;

        public StepFactory(IProvideStartupServices startupServices)
        {
            this.startupServices = startupServices;
        }


        public IRunATask create_step(Type type)
        {
            object instance = Activator.CreateInstance(type, startupServices);
            return (IRunATask)instance;
        }
    }
}