using System;

namespace ModeloMaquina{
    class Maquina{
        private int id;
        private string local;

        public Maquina(string local, int id){
            if(!string.IsNullOrEmpty(local)){
                this.local = local;
            } else {
                throw new ArgumentOutOfRangeException();
            }

            if(id >= 0){
                this.id = id;
            } else {
                throw new ArgumentOutOfRangeException();
            }
        }

        public string Local{
            set {if (!string.IsNullOrEmpty(value)) local= value;}
            get{ return local;}
        }

        public int Id{
            set {if (value > 0) id= value;}
            get{ return id;}
        }

        public override string ToString(){
            return $"{id} - {local}";
        }
}
}