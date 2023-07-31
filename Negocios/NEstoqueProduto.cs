using System;
using System.Collections.Generic;
using ModeloEstoqueProduto;

namespace NegocioEstoqueProduto
{
    class NEstoqueProduto
    {
        private static List<EstoqueProduto> estoqueProdutos = new List<EstoqueProduto>();

        public static List<EstoqueProduto> Listar()
        {
            return estoqueProdutos;
        }

        public static EstoqueProduto Listar(int id)
        {
            foreach (EstoqueProduto obj in estoqueProdutos)
                if (obj.Id == id)
                    return obj;
            return null;
        }

        public static EstoqueProduto ListarPorMaquinaEProduto(int idMaquina, int idProduto)
        {
            List<EstoqueProduto> estoqueProdutos = NEstoqueProduto.Listar();
            foreach (EstoqueProduto estoqueProduto in estoqueProdutos)
            {
                if (estoqueProduto.IdMaquina == idMaquina && estoqueProduto.IdProduto == idProduto)
                {
                    return estoqueProduto;
                }
            }
            return null; // Retorna null se não encontrar o produto na máquina
        }

        public static void Inserir(EstoqueProduto e)
        {
            int id = 0;
            foreach (EstoqueProduto obj in estoqueProdutos)
                if (obj.Id > id)
                    id = obj.Id;
            id++;
            e.Id = id;
            estoqueProdutos.Add(e);
        }

        public static void Atualizar(EstoqueProduto e)
        {
            EstoqueProduto obj = Listar(e.Id);
            if (obj != null)
            {
                obj.QuantidadeEstoque = e.QuantidadeEstoque;
            }
        }

        public static void Excluir(EstoqueProduto e)
        {
            EstoqueProduto obj = Listar(e.Id);
            if (obj != null)
                estoqueProdutos.Remove(obj);
        }

        public static List<EstoqueProduto> ListarPorMaquina(int idMaquina)
        {
            List<EstoqueProduto> estoqueDaMaquina = new List<EstoqueProduto>();

            foreach (var estoqueProduto in estoqueProdutos)
            {
                if (estoqueProduto.IdMaquina == idMaquina)
                {
                    estoqueDaMaquina.Add(estoqueProduto);
                }
            }
            return estoqueDaMaquina;
        }
    }
}
