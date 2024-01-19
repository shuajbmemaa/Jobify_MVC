using Jobify.DataAccess.Data;
using Jobify.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobify.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IPunetRepository Punet { get; private set; }
        
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Punet = new PunetRepository(_db);
        }
        

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
