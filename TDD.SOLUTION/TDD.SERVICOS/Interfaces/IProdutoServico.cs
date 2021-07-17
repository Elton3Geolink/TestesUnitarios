using System.Threading.Tasks;
using TDD.Modelos;

namespace TDD.SERVICOS
{
    public interface IProdutoServico
    {
        Task<Produto> Obter(int id);

        Task<bool> Persistir(Produto produto);
    }
}
