using Module4HW3.DataModel;

namespace Module4HW3.Services
{
    public class MyDependency : IMyDependency
    {
        public Context GetContext()
        {
            return new Context();
        }
    }
}
