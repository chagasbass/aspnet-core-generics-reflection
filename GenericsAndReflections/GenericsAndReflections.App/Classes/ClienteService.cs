using GenericsAndReflections.App.Interfaces;

namespace GenericsAndReflections.App.Classes
{
    public class ClienteService
    {
        public ClienteService(IRepository<Cliente> repository,ILogger logger)
        {

        }
    }
}
