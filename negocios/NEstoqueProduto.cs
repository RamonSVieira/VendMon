using System;
using System.Collections.Generic;

class NEstoqueProduto{
    private static List<EstoqueProduto> estoqueProdutos = new List<EstoqueProduto>();
    
    public static List<EstoqueProduto> Listar() {
        return estoqueProdutos;
    }

    public static EstoqueProduto Listar(int id) {
        foreach(EstoqueProduto obj in estoqueProdutos)
            if (obj.Id == id) return obj;
        return null;
    }

    public static void Inserir(EstoqueProduto e) {
        int id = 0;
        foreach(EstoqueProduto obj in estoqueProdutos)
            if (obj.Id > id) id = obj.Id;
        id++;
        e.Id = id;
        estoqueProdutos.Add(e);    
    }

    public static void Atualizar(EstoqueProduto e) {
        EstoqueProduto obj = Listar(e.Id);
        if (obj != null){
            obj.QuantidadeEstoque = e.QuantidadeEstoque;
        }
    }

    public static void Excluir(EstoqueProduto e) {
        EstoqueProduto obj = Listar(e.Id);
        if (obj != null) estoqueProdutos.Remove(obj);
    }
}