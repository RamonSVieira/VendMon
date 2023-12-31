using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

using ModeloProduto;

namespace NegocioProduto
{
    class NProduto
    {
        private static List<Produto> produtos = new List<Produto>();

        public static List<Produto> Listar()
        {
            return produtos;
        }

        public static Produto Listar(int id)
        {
            foreach (Produto obj in produtos)
                if (obj.Id == id)
                    return obj;
            return null;
        }

        public static void Inserir(Produto p)
        {
            int id = 0;
            foreach (Produto obj in produtos)
                if (obj.Id > id)
                    id = obj.Id;
            id++;
            p.Id = id;
            produtos.Add(p);
        }

        public static void Atualizar(Produto p)
        {
            Produto obj = Listar(p.Id);
            if (obj != null)
            {
                obj.Valor = p.Valor;
                obj.Nome = p.Nome;
                obj.TipoDoProduto = p.TipoDoProduto;
            }
        }

        public static void Excluir(Produto p)
        {
            Produto obj = Listar(p.Id);
            if (obj != null)
                produtos.Remove(obj);
        }

        public static void Salvar()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Produto>));
            using (StreamWriter f = new StreamWriter("produtos.xml"))
            {
                xml.Serialize(f, produtos);
            }
        }

        public static void Abrir()
        {
            string filePath = "produtos.xml";
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Produto>));
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    produtos = (List<Produto>)serializer.Deserialize(fileStream);
                }
            }
            else
            {
                produtos = new List<Produto>();
            }
        }
    }
}
