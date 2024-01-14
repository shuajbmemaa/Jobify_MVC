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
    public class PunaRepository :Repository<Puna>, IPunaRepository
    {
        private ApplicationDbContext _db;
        public PunaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Puna punet)
        {
            _db.Punet.Update(punet);
        }
    }
}
