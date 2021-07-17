using System.Threading.Tasks;

namespace TDD.REPOSITORIO
{
    public interface IBaseRepositorio
    {
        Task<bool> Persistir(string dado);
    }
}
