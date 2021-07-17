using System.Threading.Tasks;
using TDD.REPOSITORIO;

namespace TDD.SERVICOS
{
    public class BaseServico : IBaseServico
    {
        private readonly IBaseRepositorio _baseRepositorio;

        public BaseServico(IBaseRepositorio baseRepositorio)
        {
            _baseRepositorio = baseRepositorio;
        }

        public async Task<bool> Persistir(string dado)
        {
            return !string.IsNullOrWhiteSpace(dado);
            //return await _baseRepositorio.Persistir(dado);
        }


    }
}
