using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobify.DataAccess.Repository.IRepository
{
    public  interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IPunaRepository Puna { get; }

        IProductRepository Product { get; }

        void Save();
    }
}
