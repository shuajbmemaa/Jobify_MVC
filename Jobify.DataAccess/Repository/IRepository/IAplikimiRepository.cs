using Jobify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobify.DataAccess.Repository.IRepository
{
    public interface IAplikimiRepository : IRepository<Aplikimi>
    {
        void Update(Aplikimi aplikimi);
    }
}
