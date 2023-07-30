using System;
using System.Collections.Generic;

// Abastecimento do Sistema

class NAbastecimento{
    private static List<Abastecimento> abastecimentos = new List<Abastecimento>();
    
    public static List<Abastecimento> Listar() {
        return abastecimentos;
    }

    public static Abastecimento Listar(int id) {
        foreach(Abastecimento obj in abastecimentos)
            if (obj.Id == id) return obj;
        return null;
    }

    public static void Inserir(Abastecimento a) {
        int id = 0;
        foreach(Abastecimento obj in abastecimentos)
            if (obj.Id > id) id = obj.Id;
        id++;
        a.Id = id;
        abastecimentos.Add(a);    
    }

    public static void Atualizar(Abastecimento a) {
        Abastecimento obj = Listar(a.Id);
        if (obj != null) {
            obj.IdMaquina = a.IdMaquina;
            obj.IdProduto = a.IdProduto;
            obj.Quantidade = a.Quantidade;
        }
    }

    public static void Excluir(Abastecimento a) {
        Abastecimento obj = Listar(a.Id);
        if (obj != null) abastecimentos.Remove(obj);
    }
}