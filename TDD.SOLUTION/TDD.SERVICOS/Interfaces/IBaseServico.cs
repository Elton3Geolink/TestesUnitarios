using System.Threading.Tasks;

namespace TDD.SERVICOS
{
    public interface IBaseServico
    {
        Task<bool> Persistir(string dado);        
    }
}
