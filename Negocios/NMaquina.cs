using ModeloMaquina;

namespace NegocioMaquina{
class NMaquina{
    private static List<Maquina> maquinas = new List<Maquina>();
    private static int proximoId = 1;
    
    public static List<Maquina> Listar() {
        return maquinas;
    }

    public static Maquina Listar(int id) {
        foreach(Maquina obj in maquinas)
            if (obj.Id == id) return obj;
        return null;
    }

    public static void Inserir(Maquina m) {
        int id = 0;
        foreach(Maquina obj in maquinas)
            if (obj.Id > id) id = obj.Id;
        id++;
        m.Id = id;
        maquinas.Add(m);    
    }

    public static void Atualizar(Maquina m) {
        Maquina obj = Listar(m.Id);
        if (obj != null) obj.Local = m.Local;
    }

    public static void Excluir(Maquina m) {
        Maquina obj = Listar(m.Id);
        if (obj != null) maquinas.Remove(obj);
    }
}
}