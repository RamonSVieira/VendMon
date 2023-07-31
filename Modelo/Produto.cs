using System;

namespace ModeloProduto
{
    public class Produto
    {
        private string nome;
        private double valor;
        private int id;

        private int quantidade;
        private TipoProduto tipoDoProduto;

        public Produto() { }

        public Produto(string nome, double valor, TipoProduto tipoDoProduto, int id, int quantidade)
        { //TipoProduto enumeration
            Nome = nome;
            Valor = valor;
            TipoDoProduto = tipoDoProduto;
            Id = id;
            Quantidade = quantidade;
        }

        public string Nome
        {
            set
            {
                if (!string.IsNullOrEmpty(value))
                    nome = value;
            }
            get { return nome; }
        }

        public Double Valor
        {
            set
            {
                if (value > 0)
                    valor = value;
            }
            get { return valor; }
        }

        public int Id
        {
            set
            {
                if (value > 0)
                    id = value;
            }
            get { return id; }
        }

        public TipoProduto TipoDoProduto
        {
            set { this.tipoDoProduto = value; }
            get { return tipoDoProduto; }
        }

        public int Quantidade
        {
            set
            {
                if (value >= 0)
                    quantidade = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
            get { return quantidade; }
        }

        public override string ToString()
        {
            return $"{nome} - {valor} - {tipoDoProduto} - {id}";
        }
    }

    public enum TipoProduto
    {
        Refrigerante,
        Chocolate,
        Salgados
    }
}
