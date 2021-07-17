using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using TDD.SERVICOS;
using TDD.REPOSITORIO;

namespace TDD.Xunit
{
    
    public class BaseTeste
    {
        [Fact]
        public async Task TestarBase()
        {
            Mock<IBaseRepositorio> mock = new Mock<IBaseRepositorio>();
            mock.Setup(x => x.Persistir(It.IsAny<string>())).ReturnsAsync(false);
                        
            
            BaseServico baseServico = new BaseServico(mock.Object);
            bool sucesso =  await baseServico.Persistir("asdf");

            mock.Verify();
            Assert.True(sucesso);
        }
    }
}
