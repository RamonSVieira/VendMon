using System;
using System.Collections.Generic;

class NProduto{
    private static List<Produto> produtos = new List<Produto>();
    
    public static List<Produto> Listar() {
        return produtos;
    }

    public static Produto Listar(int id) {
        foreach(Produto obj in produtos)
            if (obj.Id == id) return obj;
        return null;
    }

    public static void Inserir(Produto p) {
        int id = 0;
        foreach(Produto obj in produtos)
            if (obj.Id > id) id = obj.Id;
        id++;
        p.Id = id;
        produtos.Add(p);    
    }

    public static void Atualizar(Produto p) {
        Produto obj = Listar(p.Id);
        if (obj != null){
            obj.Valor = p.Valor; 
            obj.Nome = p.Nome; 
            obj.TipoProduto = p.TipoProduto;
        } 
    }

    public static void Excluir(Produto p) {
        Produto obj = Listar(p.Id);
        if (obj != null) produtos.Remove(obj);
    }
}