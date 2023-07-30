using System;

class Produto{
    private string nome;
    private double valor;
    private int id;
    private TipoProduto tipoDoProduto;

    public Produto(string nome, double valor, TipoProduto tipoDoProduto, int id){ //TipoProduto enumeration
        if(!string.IsNullOrEmpty(nome)){
            this.nome = nome;
        } else {
            throw new ArgumentOutOfRangeException();
        }

        if(valor > 0){
            this.valor = valor;
        } else {
            throw new ArgumentOutOfRangeException();
        }

        if(id >= 0){
            this.id = id;
        } else {
            throw new ArgumentOutOfRangeException();
        }

        this.tipoDoProduto = tipoDoProduto;
    }

    public string Nome{
        set {if (!string.IsNullOrEmpty(value)) nome = value;}
        get{ return nome;}
    }

    public Double Valor{
        set {if (value > 0) valor = value;}
        get{ return valor;}
    }

    public int Id{
        set {if (value > 0) Id = value;}
        get{ return id;}
    }

    public TipoProduto TipoDoProduto { get; }

    public override string ToString(){
        return $"{nome} - {valor} - {tipoDoProduto} - {id}";
    }
}

enum TipoProduto
{
    Refrigerante,
    Chocolate,
    Salgados
}