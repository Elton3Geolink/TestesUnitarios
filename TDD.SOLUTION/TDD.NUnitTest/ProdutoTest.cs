using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Modelos;
using TDD.REPOSITORIO;
using TDD.SERVICOS;

namespace TDD.NUnitTest
{

        
    public class ProdutoTest: MockBaseTeste
    {

        [Test]
        public async Task TestarAtualizacaoProdutoMocadoExistente()
        {

            //Mock<IProdutoRepositorio> mockRepositorio = new Mock<IProdutoRepositorio>();

            //Importante: Mocar o retorno do metodo "Obter". Desta forma posso ignorar a existencia ou nao deste metodo e/ou classe concreta.
            //Basta ter a interface e boas.
            mockRepositorio.Setup(x => x.Obter(It.IsAny<int>())).ReturnsAsync(new Produto(1, "Vassoura", 10));
            
            //Mocando o retorno do metodo "Persistir". 
            //Importante: saiba o quê mocar, nem tudo faz sentido. Depende da parte do codigo (metodo) deseja-se realizar o teste.
            mockRepositorio.Setup(x => x.Persistir(It.IsAny<Produto>())).ReturnsAsync(true);

            ProdutoServico produtoServico = new ProdutoServico(mockRepositorio.Object);
            bool sucesso = await produtoServico.Persistir(new Produto(1, "Vassoura", 10));

            mockRepositorio.Verify();
            Assert.IsTrue(sucesso);

        }



        [Test]
        public async Task TestarAtualizacaoProdutoExistente()
        {            
            ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio();

            ProdutoServico produtoServico = new ProdutoServico(produtoRepositorio);
            var produto = await produtoServico.Obter(1);

            bool sucesso = await produtoServico.Persistir(new Produto(produto.Id, "Vassoura azul", 11));
            
            Assert.IsTrue(sucesso);
        }


        [Test]
        public async Task TestarAtualizacaoProdutoNaoExistenteException()
        {

            Mock<IProdutoRepositorio> mockRepositorio = new Mock<IProdutoRepositorio>();

            mockRepositorio.Setup(x => x.Obter(It.IsAny<int>())).ReturnsAsync(new Produto(2, "Vassoura", 10));
            mockRepositorio.Setup(x => x.Persistir(It.IsAny<Produto>())).ReturnsAsync(true);

            ProdutoServico produtoServico = new ProdutoServico(mockRepositorio.Object);            

            mockRepositorio.Verify();

            var ex = Assert.ThrowsAsync<Exception>(async () => await produtoServico.Persistir(new Produto(1, "Vassoura", 10)));
            Assert.That(ex.Message, Is.EqualTo("Produto nao encontrado"));

        }

        [Test]
        public async Task ObterProdutoExistente_TesteServico()
        {
            var produtoRepositorioMock = new Mock<IProdutoRepositorio>();
            produtoRepositorioMock.Setup(x => x.Obter(It.IsAny<int>())).ReturnsAsync(new Produto(1, "Produto teste",2));


            ProdutoServico produtoServico = new ProdutoServico(produtoRepositorioMock.Object);

            //Obs.: Nao faz nem sentido chamar o metodo pois o setup do Mock acima (produtoRepositorioMock) já força o resultado,
            //ou seja, o obter abaixo vai sempre retornar o dado forçado pelo mock.
            var produto = await produtoServico.Obter(10);

            Assert.AreEqual(produto.Id, 1);
            Assert.AreEqual(produto.Nome, "Produto teste");
            Assert.AreEqual(produto.Preco, 2);
        }

        [Test]
        public async Task ObterProdutoExistente_TesteRepositorioMock()
        {
            var produtoRepositorioMock = new Mock<IProdutoRepositorio>();
            produtoRepositorioMock.Setup(x => x.Obter(It.IsAny<int>())).ReturnsAsync(new Produto(1, "Produto teste", 2));

            var produto = await produtoRepositorioMock.Object.Obter(1);

            Assert.AreEqual(produto.Id, 1);
            Assert.AreEqual(produto.Nome, "Produto teste");
            Assert.AreEqual(produto.Preco, 2);
        }
    }
}
