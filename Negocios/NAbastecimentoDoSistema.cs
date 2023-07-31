using System;
using System.Collections.Generic;
using ModeloAbastecimentoDoSistema;

// Abastecimento do Sistema
namespace NegocioAbastecimento
{
    class NAbastecimento
    {
        private static List<AbastecimentoDoSistema> abastecimentos =
            new List<AbastecimentoDoSistema>();

        public static List<AbastecimentoDoSistema> Listar()
        {
            return abastecimentos;
        }

        public static AbastecimentoDoSistema Listar(int id)
        {
            foreach (AbastecimentoDoSistema obj in abastecimentos)
                if (obj.Id == id)
                    return obj;
            return null;
        }

        public static void Inserir(AbastecimentoDoSistema a)
        {
            int id = 0;
            foreach (AbastecimentoDoSistema obj in abastecimentos)
                if (obj.Id > id)
                    id = obj.Id;
            id++;
            a.Id = id;
            abastecimentos.Add(a);
        }

        public static void Atualizar(AbastecimentoDoSistema a)
        {
            AbastecimentoDoSistema obj = Listar(a.Id);
            if (obj != null)
            {
                obj.IdMaquina = a.IdMaquina;
                obj.IdProduto = a.IdProduto;
                obj.QuantidadeDoAbastecimento = a.QuantidadeDoAbastecimento;
            }
        }

        public static void Excluir(AbastecimentoDoSistema a)
        {
            AbastecimentoDoSistema obj = Listar(a.Id);
            if (obj != null)
                abastecimentos.Remove(obj);
        }
    }
}
