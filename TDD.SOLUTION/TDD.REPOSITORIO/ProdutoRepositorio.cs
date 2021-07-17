using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDD.Modelos;

namespace TDD.REPOSITORIO
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly List<Produto> produtos;

        public ProdutoRepositorio()
        {
            this.produtos = new List<Produto>();

            this.produtos.Add(new Produto(1, "Vassoura", 10));
            this.produtos.Add(new Produto(2, "Tesoura", 5));
        }

        public async Task<Produto> Obter(int id)
        {
            return this.produtos.FirstOrDefault(x => x.Id == id);
        }

        public async Task<bool> Persistir(Produto produto)
        {
            var produtoExistente = produtos.First(x => x.Id == produto.Id);

            if (produtoExistente == null)
                throw new Exception("Produto nao encontrado");

            produtoExistente = produto;

            return true;
        }
    }
}
