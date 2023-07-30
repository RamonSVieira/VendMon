using System;

class EstoqueProduto{
    private int id;
    private int idMaquina;
    private int idProduto;
    private int quantidadeEstoque;
    private int estoqueMaximo;

    public EstoqueProduto(int id, int idMaquina, int idProduto, int quantidadeEstoque, int estoqueMaximo){ 
        if(id >= 0){
            this.id = id;
        } else {
            throw new ArgumentOutOfRangeException();
        }

        if(idMaquina >= 0){
            this.idMaquina = idMaquina;
        } else {
            throw new ArgumentOutOfRangeException();
        }

        if(idProduto >= 0){
            this.idProduto = idProduto;
        } else {
            throw new ArgumentOutOfRangeException();
        }

        if(quantidadeEstoque >= 0){
            this.quantidadeEstoque = quantidadeEstoque;
        } else {
            throw new ArgumentOutOfRangeException();
        }

        if(estoqueMaximo >= 0){
            this.estoqueMaximo = estoqueMaximo;
        } else {
            throw new ArgumentOutOfRangeException();
        }
        
    }

    public int Id{
        set {if (value > 0) this.id = value;}
        get {return this.id;}
    }

    public int IdMaquina{
        set {if (value > 0) this.idMaquina = value;}
        get {return this.idMaquina;}
    }

    public int idProduto{
        set {if (value > 0) this.idProduto = value;}
        get {return this.idProduto;}
    }
    
    public int QuantidadeEstoque{
        set {if (value > 0) this.quantidadeEstoque = value;}
        get {return this.quantidadeEstoque;}
    }

    public int EstoqueProduto{
        set {if (value > 0) this.estoqueMaximo = value;}
        get {return this.estoqueMaximo;}
    }

    public override string ToString(){
        return $"{id} - {idMaquina} - {idProduto} - {quantidadeEstoque} - {estoqueMaximo}";
    }
}
