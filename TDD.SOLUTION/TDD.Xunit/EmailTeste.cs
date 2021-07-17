using System;
using Xunit;
using TDD.SERVICOS;
using System.Threading.Tasks;
using TDD.REPOSITORIO;

namespace TDD.Xunit
{
    public class EmailTeste
    {
        [Fact]
        public async Task TestarEmail()
        {            
            EmailRepositorio emailRepositorio = new EmailRepositorio();
            EmailServico emailServico = new EmailServico(emailRepositorio);

            bool sucesso = await emailServico.EnviarEmail();

            Assert.True(sucesso);
        }




    }
}
