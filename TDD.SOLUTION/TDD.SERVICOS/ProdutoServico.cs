using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Modelos;
using TDD.REPOSITORIO;

namespace TDD.SERVICOS
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoServico(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        public async Task<Produto> Obter(int id)
        {
            return await _produtoRepositorio.Obter(id);
        }

        public async Task<bool> Persistir(Produto produto)
        {
            var produtoOriginal = await Obter(produto.Id);

            if (produtoOriginal == null || produto.Id != produtoOriginal.Id)
                throw new Exception("Produto nao encontrado");

            return await _produtoRepositorio.Persistir(produto);
        }
    }
}
