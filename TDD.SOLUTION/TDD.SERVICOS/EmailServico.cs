using System.Threading.Tasks;
using TDD.REPOSITORIO;

namespace TDD.SERVICOS
{
    public class EmailServico
    {
        private readonly EmailRepositorio _emailRepositorio;

        public EmailServico(EmailRepositorio emailRepositorio)
        {
            _emailRepositorio = emailRepositorio;
        }

        public async Task<bool> EnviarEmail()
        {
            return await _emailRepositorio.EnviarEmail();            
        }
    }
}
