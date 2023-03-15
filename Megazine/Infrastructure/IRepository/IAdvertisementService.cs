using Megazine.Models;

namespace Megazine.Infrastructure.IRepository
{
    public interface IAdvertisementService
    {
        void Delete(Advertisement demoadvertisement);
        List<Advertisement> GetAll();
        Advertisement GetById(int Id);
        List<Advertisement> GetByName(string demoname);
        Advertisement Save(Advertisement demoadvertisement);
        Advertisement Update(Advertisement demoadvertisement);
    }
}