using System;

namespace ModeloProduto
{
    class Produto
    {
        private string nome;
        private double valor;
        private int id;

        private int quantidade;
        private TipoProduto tipoDoProduto;

        public Produto(string nome, double valor, TipoProduto tipoDoProduto, int id, int quantidade)
        { //TipoProduto enumeration
            if (!string.IsNullOrEmpty(nome))
            {
                this.nome = nome;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            if (valor > 0)
            {
                this.valor = valor;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            if (id >= 0)
            {
                this.id = id;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            if (quantidade > 0)
            {
                this.quantidade = quantidade;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            this.tipoDoProduto = tipoDoProduto;
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

    enum TipoProduto
    {
        Refrigerante,
        Chocolate,
        Salgados
    }
}
