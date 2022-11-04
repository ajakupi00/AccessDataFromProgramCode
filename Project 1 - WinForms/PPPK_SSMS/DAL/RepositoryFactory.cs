using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak.Dal;

namespace PPPK_SSMS.DAL
{
    public static class RepositoryFactory
    {
        private static readonly Lazy<IRepository> repository = new Lazy<IRepository>(() => new SqlRepository());

        public static IRepository GetRepository() => repository.Value;

    }
}
