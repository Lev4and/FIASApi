using FIASApi.Model.Repositories.Abstract;

namespace FIASApi.Model
{
    public class DataManager
    {
        public IAddrobRepository Addrobs { get; set; }

        public DataManager(IAddrobRepository addrobRepository)
        {
            Addrobs = addrobRepository;
        }
    }
}
