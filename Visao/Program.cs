using System;
using ModeloMaquina;

namespace VendMon{

    class Program{

        public static void Main(string[] args){
            Program program = new Program();

            Console.WriteLine("Bem-vindo ao sistema Vendmon!");

            bool continuar = true;
            while (continuar){
                Console.WriteLine("\n------- Menu Principal -------");
                Console.WriteLine("| 1 - Administração         |");
                Console.WriteLine("| 2 - Visitante             |");
                Console.WriteLine("| 0 - Sair do Sistema       |");
                Console.WriteLine("-----------------------------");
                Console.Write("\nOpção: ");

                string opcao = Console.ReadLine();

                if (opcao == "1"){
                    program.MenuAdmin();
                    break;
                }
                else if (opcao == "2"){
                    program.MenuVisitante();
                    break;
                }
                else if (opcao == "0"){
                    continuar = false;
                    break;
                }
                else{
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
                }
            }
        }

        public void MenuAdmin(){
            Console.WriteLine("------- Opções -------");
            Console.WriteLine("------ Produtos ------");
            Console.WriteLine("| 01 - Listar        |");
            Console.WriteLine("| 02 - Inserir       |");
            Console.WriteLine("| 03 - Atualizar     |");
            Console.WriteLine("| 04 - Excluir       |");
            Console.WriteLine("|                    |");
            Console.WriteLine("------ Maquinas ------");
            Console.WriteLine("| 05 - Listar        |");
            Console.WriteLine("| 06 - Inserir       |");
            Console.WriteLine("| 07 - Atualizar     |");
            Console.WriteLine("| 08 - Excluir       |");
            Console.WriteLine("----------------------");
            Console.WriteLine("| 99 - Sair          |");
            Console.WriteLine("| 00 - Fim           |");
            Console.WriteLine("----------------------");
            Console.Write("\nOpção: ");
            int.Parse(Console.ReadLine());
        }

        public void MenuVisitante(){
            Console.WriteLine("--------- Opções --------");
            Console.WriteLine("| 01 - Escolher Produto |");
            Console.WriteLine("| 02 - Pagar Produto    |");
            Console.WriteLine("--------------------------");
            Console.WriteLine("| 00 - Fim            |");
            Console.WriteLine("--------------------------");
            Console.Write("\nOpção: ");
            int.Parse(Console.ReadLine());
        }

        public void EscolherMaquina(){
            // Listando as máquinas
            var maquinas = NMaquina.Listar();
            foreach (var maquina in maquinas){
                Console.WriteLine($"{maquina.Id} - {maquina.Local}");
            }
            // Escolhendo a máquina pelo id
            Console.Write("Digite o ID da máquina desejada: ");
            int idMaquina = int.Parse(Console.ReadLine());
            // Maquina maquina = NMaquina.Listar(idMaquina);

            if (idMaquina != null){
                ExibirVitrine(maquina); 
            }
            else {
                Console.WriteLine("Máquina não encontrada.");
            }
        }

        public void ExibirVitrine(Maquina maquina){
            Console.WriteLine($"Vitrine da Máquina - {maquina.Local}");
            // Listando os produtos da maquina escolhida
            List<EstoqueProduto> estoque = NEstoqueProduto.Listar(idMaquina); 
            foreach (var estoqueProduto in estoque){
                // Listando os produtos que estão no estoque da máquina
                Produto produto = NProduto.Listar(estoqueProduto.IdProduto);
                Console.WriteLine($"{produto.Id} - {produto.Nome} - R${produto.Valor}");
            }
        }

        public void EscolherProduto(){

        }

        public void VerificarPagamento(){

        }

        public void CadastrarProduto(){
            // inserir produto no sistema
            Console.WriteLine("Inserção de produto no sistema");
            Console.Write("Informe o nome do produto: ");
            string n = Console.ReadLine();

            Console.Write("Informe o valor do produto: ");
            double v = double.Parse(Console.ReadLine());

            Console.Write("Informe o tipo do produto: ");
            TipoDoProduto t = TipoDoProduto.Parse(Console.ReadLine());

            // Verificando o ID da última máquina na lista de máquinas
            int ultimoId = 0;
            List<Produto> produtos = NProduto.Listar();
            foreach (Produto produto in Produtos){
                if (produto.Id > ultimoId){
                    ultimoId = produto.Id;
                }
            }
            // Incrementando o ID para criar o novo ID da máquina
            int novoId = ultimoId + 1;

            Produto p = new Produto(n, v, t, novoId);
            NProduto.Inserir(p);
            Console.WriteLine("Produto inserido com sucesso!");
        }

        public void CadastrarMaquina(){
            // inserir maquina no sistema
            Console.WriteLine("Inserção de máquina no sistema");
            Console.Write("Informe a localização da máquina: ");
            string local = Console.ReadLine();
            // Verificando o ID da última máquina na lista de máquinas
            int ultimoId = 0;
            List<Maquina> maquinas = NMaquina.Listar();
            foreach (Maquina maquina in maquinas){
                if (maquina.Id > ultimoId){
                    ultimoId = maquina.Id;
                }
            }
            // Incrementando o ID para criar o novo ID da máquina
            int novoId = ultimoId + 1;

            Maquina m = new Maquina(local, novoId); //?
            NMaquina.Inserir(m);
            Console.WriteLine("Máquina inserida com sucesso!");
        }

        public void AbastecerMaquina(){
       
        }

        public void EntrarSistema(){

        }

        public void SairSistema(){
            Console.WriteLine("Saindo do sistema...");
            Environment.Exit(0);
        }
    }
}