using Jobify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jobify.DataAccess.Repository.IRepository
{
    public interface IPunetRepository: IRepository<Punet>
    {
        void Update(Punet obj);

        IEnumerable<string> GetKategorite();

       // List<Punet> GetPunetByCategory(string k);
    }
}
