using System;
using System.Threading.Tasks;

namespace TDD.REPOSITORIO
{
    public class BaseRepositorio : IBaseRepositorio
    {
        public async Task<bool> Persistir(string dado)
        {
            return !string.IsNullOrWhiteSpace(dado);
            //throw new NotImplementedException();
        }
    }
}
