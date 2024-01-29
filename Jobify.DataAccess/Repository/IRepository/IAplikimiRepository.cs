using Jobify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Jobify.DataAccess.Repository.IRepository
{
    public interface IAplikimiRepository : IRepository<Aplikimi>
    {
        bool Exists(Expression<Func<Aplikimi, bool>> filter);
        void Update(Aplikimi aplikimi);
    }
}
