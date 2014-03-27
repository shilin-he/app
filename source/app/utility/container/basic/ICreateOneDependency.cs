namespace app.utility.container.basic
{
  public interface ICreateOneDependency
  {
    object create();
  }

  class LifecycleAware : ICreateOneDependency
  {
    ICreateOneDependency factory;
    IManageTheLifecycleOfAComponent life_cycle;

    public LifecycleAware(ICreateOneDependency factory, IManageTheLifecycleOfAComponent life_cycle)
    {
      this.factory = factory;
      this.life_cycle = life_cycle;
    }

    public object create()
    {
      return life_cycle.apply_to(factory);
    }
  }
}