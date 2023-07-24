using System;

class Maquina{
    public int id;
    public string local;

    public Maquina(string local){
        Local = local;
    }

    public string Local{
        set {if (!string.IsNullOrEmpty(value)) local= value;}
        get{ return local;}
    }

    public int Id{
        set {if (value > 0) Id = value;}
        get{ return id;}
    }

    public override string ToString(){
        return $"{Id} - {Local}";
    }
}