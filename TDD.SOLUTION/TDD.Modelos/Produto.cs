using System;

namespace TDD.Modelos
{
    public class Produto
    {
        public Produto(int id, string nome, decimal preco)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }

    }
}
