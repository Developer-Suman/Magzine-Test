using Megazine.Data;
using Megazine.Infrastructure.IRepository;
using Megazine.Models;
using Microsoft.AspNetCore.Mvc;

namespace Megazine.Infrastructure.Repository
{

    public class AdvertisementService : IAdvertisementService
    {
        public AppDbContext _context { get; set; }
        public AdvertisementService(AppDbContext context)
        {
            _context = context;
        }

        public List<Advertisement> GetAll()
        {
            return _context.Advertisements.ToList();
        }

        public List<Advertisement> GetByName(string demoname)
        {
            var linq = from advertisement in _context.Advertisements select advertisement;
            return linq.ToList();
        }

        public Advertisement GetById(int Id)
        {
            var A = _context.Advertisements.Find(Id);
            return A;
        }

        public Advertisement Save(Advertisement demoadvertisement)
        {
            _context.Advertisements.Add(demoadvertisement);
            _context.SaveChanges();
            return demoadvertisement;

        }

        public Advertisement Update(Advertisement demoAdvertisement)
        {
            Advertisement AdvertiseFromDb = _context.Advertisements.First(x => x.Id == demoAdvertisement.Id);
            AdvertiseFromDb.OwenerName = demoAdvertisement.OwenerName;
            AdvertiseFromDb.CreatedDate = demoAdvertisement.CreatedDate;
            AdvertiseFromDb.Amount = demoAdvertisement.Amount;

            if (demoAdvertisement.advertiseImageFile != null)
            {
                AdvertiseFromDb.advertiseImageFile = demoAdvertisement.advertiseImageFile;
                AdvertiseFromDb.advertiseImage = demoAdvertisement.advertiseImage;
            }

            _context.Entry(AdvertiseFromDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;



            //_context.Entry(AdvertiseFromDb).CurrentValues.SetValues(demoadvertisement);
            _context.SaveChanges();
            return demoAdvertisement;

        }

        public void Delete(Advertisement demoadvertisement)
        {
            _context.Entry(demoadvertisement).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
