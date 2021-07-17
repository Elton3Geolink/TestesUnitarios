using System.Threading.Tasks;
using TDD.Modelos;

namespace TDD.REPOSITORIO
{
    public interface IProdutoRepositorio
    {
        Task<Produto> Obter(int id);

        Task<bool> Persistir(Produto produto);
    }
}
