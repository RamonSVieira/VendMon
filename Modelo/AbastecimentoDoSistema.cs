using System;

namespace ModeloAbastecimentoDoSistema
{
    class AbastecimentoDoSistema
    {
        private int id;
        private int idMaquina;
        private int idProduto;
        private DateTime data;
        private int quantidadeAbastecimento;

        public AbastecimentoDoSistema() { }

        public AbastecimentoDoSistema(
            int id,
            int idMaquina,
            int idProduto,
            DateTime data,
            int quantidadeAbastecimento
        )
        {
            if (id >= 0)
            {
                this.id = id;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            if (idMaquina >= 0)
            {
                this.idMaquina = idMaquina;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            if (idProduto >= 0)
            {
                this.idProduto = idProduto;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            this.data = data;

            if (quantidadeAbastecimento >= 0)
            {
                this.quantidadeAbastecimento = quantidadeAbastecimento;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public int Id
        {
            set
            {
                if (value > 0)
                    this.id = value;
            }
            get { return this.id; }
        }

        public int IdMaquina
        {
            set
            {
                if (value > 0)
                    this.idMaquina = value;
            }
            get { return this.idMaquina; }
        }

        public int IdProduto
        {
            set
            {
                if (value > 0)
                    this.idProduto = value;
            }
            get { return this.idProduto; }
        }

        public int QuantidadeDoAbastecimento
        {
            set
            {
                if (value > 0)
                    this.quantidadeAbastecimento = value;
            }
            get { return this.quantidadeAbastecimento; }
        }

        public DateTime DataDoAbastecimento
        {
            set { this.data = value; }
            get { return this.data; }
        }

        public override string ToString()
        {
            return $"{id} - {idMaquina} - {idProduto} - {quantidadeAbastecimento} - {data}";
        }
    }
}
