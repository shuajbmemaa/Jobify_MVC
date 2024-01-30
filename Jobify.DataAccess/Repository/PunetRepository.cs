using Jobify.DataAccess.Data;
using Jobify.DataAccess.Repository.IRepository;
using Jobify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jobify.DataAccess.Repository
{
    public class PunetRepository :Repository<Punet>, IPunetRepository
    {
        private ApplicationDbContext _db;
        public PunetRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<string> GetKategorite()
        {
            return _db.Punet.Select(k => k.kategoria).Distinct().ToList();
        }

        public List<Punet> GetPunetByCategory(string kategori)
        {
            return _db.Punet.Where(j => j.kategoria == kategori).ToList();
        }

        public void Update(Punet obj)
        {
            _db.Punet.Update(obj);
        }

       //public List<Punet> GetPunetByCategory(string kategori)
       // {
       //     return _db.Punet.Where(j =>j.kategoria == kategori);
       // }



    }
}
