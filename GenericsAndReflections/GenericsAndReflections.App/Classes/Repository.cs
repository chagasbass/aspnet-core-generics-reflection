using GenericsAndReflections.App.Interfaces;

namespace GenericsAndReflections.App.Classes
{
    public class Repository<T>:IRepository<T>
    {
        public Repository(ILogger logger)
        {

        }
    }
}
