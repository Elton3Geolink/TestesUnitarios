using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using TDD.REPOSITORIO;
using TDD.SERVICOS;

namespace TDD.NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task TestarBaseServico()
        {
            Mock<IBaseRepositorio> mock = new Mock<IBaseRepositorio>();
            mock.Setup(x => x.Persistir(It.IsAny<string>())).ReturnsAsync(false);


            BaseServico baseServico = new BaseServico(mock.Object);
            bool sucesso = await baseServico.Persistir("asdf");

            mock.Verify();
            Assert.True(sucesso);
        }
    }
}