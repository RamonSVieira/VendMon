using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

using ModeloMaquina;

namespace NegocioMaquina
{
    class NMaquina
    {
        private static List<Maquina> maquinas = new List<Maquina>();
        private static int proximoId = 1;

        public static List<Maquina> Listar()
        {
            return maquinas;
        }

        public static Maquina Listar(int id)
        {
            foreach (Maquina obj in maquinas)
                if (obj.Id == id)
                    return obj;
            return null;
        }

        public static void Inserir(Maquina m)
        {
            int id = 0;
            foreach (Maquina obj in maquinas)
                if (obj.Id > id)
                    id = obj.Id;
            id++;
            m.Id = id;
            maquinas.Add(m);
        }

        public static void Atualizar(Maquina m)
        {
            Maquina obj = Listar(m.Id);
            if (obj != null)
                obj.Local = m.Local;
        }

        public static void Excluir(Maquina m)
        {
            Maquina obj = Listar(m.Id);
            if (obj != null)
                maquinas.Remove(obj);
        }

        public static void Salvar()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Maquina>));
            using (StreamWriter f = new StreamWriter("maquinas.xml"))
            {
                xml.Serialize(f, maquinas);
            }
        }

        public static void Abrir()
        {
            string filePath = "maquinas.xml";
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Maquina>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    maquinas = (List<Maquina>)serializer.Deserialize(fileStream);
                }
            }
            else
            {
                maquinas = new List<Maquina>();
            }
        }
    }
}
