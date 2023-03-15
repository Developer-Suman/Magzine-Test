using Megazine.Data;
using Megazine.Infrastructure.IRepository;
using Megazine.Models;

namespace Megazine.Infrastructure.Repository
{
    public class JournalService : IJournalService
    {
        public AppDbContext _context { get; set; }
        public JournalService(AppDbContext demoJournal)
        {
            _context = demoJournal;
        }

        public List<Journal> GetAll()
        {
            return _context.Journals.ToList();
        }

        public List<Journal> GetByName(string demoname)
        {
            var linq = from journals in _context.Journals select journals;
            return linq.ToList();
        }

        public Journal GetSingleData(int id)
        {
            var singleData = _context.Journals.SingleOrDefault(journal => journal.Id == id);
            return singleData;
        }
        public Journal GetById(int Id)
        {
            var journal = _context.Journals.Find(Id);
            return journal;
        }

        public Journal Save(Journal demojournal)
        {
            _context.Journals.Add(demojournal);
            _context.SaveChanges();
            return demojournal;

        }

        public Journal Update(Journal demoJournal)
        {
            Journal JournalFromDb = _context.Journals.First(x => x.Id == demoJournal.Id);

            JournalFromDb.Author = demoJournal.Author;
            JournalFromDb.Description = demoJournal.Description;
            JournalFromDb.CreatedDate = demoJournal.CreatedDate;
            JournalFromDb.Title = demoJournal.Title;

            if (demoJournal.JournalImageFile != null)
            {
                JournalFromDb.JournalImageFile = demoJournal.JournalImageFile;
                JournalFromDb.JournalImage = demoJournal.JournalImage;
            }

            _context.Entry(JournalFromDb).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _context.SaveChanges();
            return demoJournal;

        }

        public void Delete(Journal demojournal)
        {
            _context.Entry(demojournal).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();

        }
    }
}
