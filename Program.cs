using System;
using System.Collections.Generic;

using ModeloMaquina;
using ModeloProduto;
using ModeloEstoqueProduto;
using ModeloAbastecimentoDoSistema;

using NegocioAbastecimento;
using NegocioEstoqueProduto;
using NegocioMaquina;
using NegocioProduto;

namespace VendMon
{
    class Program
    {
        public static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("Bem-vindo ao sistema Vendmon!");

            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("\n------- Menu Principal -------");
                Console.WriteLine("| 1 - Administração         |");
                Console.WriteLine("| 2 - Visitante             |");
                Console.WriteLine("| 0 - Sair do Sistema       |");
                Console.WriteLine("-----------------------------");
                Console.Write("\nOpção: ");

                int opcao = int.Parse(Console.ReadLine());

                while (opcao != -1)
                {
                    if (opcao == 1)
                    {
                        //MOSTRA OPÇÕES
                        program.MenuAdmin();

                        int opcaoAdm = int.Parse(Console.ReadLine());
                        while (opcaoAdm != -1)
                        {
                            switch (opcaoAdm)
                            {
                                case 1:
                                    program.ListarProduto();
                                    break;
                                case 2:
                                    program.CadastrarProduto();
                                    break;
                                case 3:
                                    program.AtualizarProduto();
                                    break;
                                case 4:
                                    program.ExcluirProduto();
                                    break;
                                case 5:
                                    program.ListarMaquina();
                                    break;
                                case 6:
                                    program.CadastrarMaquina();
                                    break;
                                case 7:
                                    program.AtualizarMaquina();
                                    break;
                                case 8:
                                    program.ExcluirMaquina();
                                    break;
                                case 9:
                                    program.AbastecerMaquina();
                                    break;
                                case 10:
                                    opcaoAdm = -1;
                                    break;
                                case 0:
                                    program.SairSistema();
                                    break;
                            }

                            if (opcaoAdm == -1)
                            {
                                break;
                            }
                            program.MenuAdmin();

                            opcaoAdm = int.Parse(Console.ReadLine());
                        }
                        break;
                    }
                    else if (opcao == 2)
                    {
                        program.MenuVisitante();
                        int opcaoVisi = int.Parse(Console.ReadLine());
                        while (opcaoVisi != -1)
                        {
                            switch (opcaoVisi)
                            {
                                case 1:
                                    program.EscolherMaquina();
                                    break;
                                case 0:
                                    program.SairSistema();
                                    break;
                            }
                            program.MenuVisitante();

                            opcaoVisi = int.Parse(Console.ReadLine());
                        }
                        break;
                    }
                    else if (opcao == 0)
                    {
                        continuar = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                    }
                }
            }
        }

        public void MenuAdmin()
        {
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
            Console.WriteLine("----- Abastecer ------");
            Console.WriteLine("| 09 - Abastecer     |");
            Console.WriteLine("----------------------");
            Console.WriteLine("| 10 - Menu Principal|");
            Console.WriteLine("| 00 - Fim           |");
            Console.WriteLine("----------------------");
            Console.Write("\nOpção: ");
        }

        public void MenuVisitante()
        {
            Console.WriteLine("--------- Opções --------");
            Console.WriteLine("| 01 - Comprar Produto  |");
            Console.WriteLine("--------------------------");
            Console.WriteLine("| 00 - Fim              |");
            Console.WriteLine("--------------------------");
            Console.Write("\nOpção: ");
        }

        //==========================PRODUTO ==========================

        public void ListarProduto()
        {
            // Listando as máquinas
            var produtos = NProduto.Listar();
            Console.WriteLine($"Produtos:");
            foreach (var produto in produtos)
            {
                Console.WriteLine(
                    $"{produto.Id} - {produto.Nome} - {produto.Valor:F2} - {produto.TipoDoProduto} - {produto.Quantidade}"
                );
            }
            Console.WriteLine($"\n");
        }

        public void CadastrarProduto()
        {
            // Inserção de produto no sistema
            Console.WriteLine("Inserção de produto no sistema");

            Console.Write("Informe o nome do produto: ");
            string n = Console.ReadLine();

            Console.Write("Informe o valor do produto: ");
            double v = double.Parse(Console.ReadLine());

            Console.Write("Informe a quantidade do produto: ");
            int q = int.Parse(Console.ReadLine());

            Console.Write("Informe o tipo do produto (Refrigerante, Chocolate, Salgados): ");
            string tipoProdutoInput = Console.ReadLine();
            if (Enum.TryParse<TipoProduto>(tipoProdutoInput, out TipoProduto t))
            {
                // Verificando o ID do último produto na lista de produtos
                int ultimoId = 0;
                List<Produto> produtos = NProduto.Listar();
                foreach (Produto produto in produtos)
                {
                    if (produto.Id > ultimoId)
                    {
                        ultimoId = produto.Id;
                    }
                }
                // Incrementando o ID para criar o novo ID do produto
                int novoId = ultimoId + 1;

                Produto p = new Produto(n, v, t, novoId, q);
                NProduto.Inserir(p);
                Console.WriteLine("Produto inserido com sucesso!");
            }
            else
            {
                Console.WriteLine(
                    "Tipo de produto inválido. Certifique-se de digitar Refrigerante, Chocolate ou Salgados."
                );
            }
        }

        public void AtualizarProduto()
        {
            ListarProduto();

            Console.WriteLine("Digite o id do produto que deseja atualizar");

            int id = int.Parse(Console.ReadLine());

            Produto p = NProduto.Listar(id);

            if (p != null)
            {
                Console.Write("Informe o nome do produto: ");
                string n = Console.ReadLine();

                Console.Write("Informe o valor do produto: ");
                double v = double.Parse(Console.ReadLine());

                Console.Write("Informe o tipo do produto (Refrigerante, Chocolate, Salgados): ");
                string tipoProdutoInput = Console.ReadLine();

                if (Enum.TryParse<TipoProduto>(tipoProdutoInput, out TipoProduto tipoDoProduto))
                {
                    p.Nome = n;
                    p.Valor = v;
                    p.TipoDoProduto = tipoDoProduto;

                    NProduto.Atualizar(p);
                    Console.WriteLine("Produto atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine(
                        "Tipo de produto inválido. Certifique-se de digitar Refrigerante, Chocolate ou Salgados."
                    );
                }
            }
            else
            {
                Console.WriteLine("Produto não encontrado. Verifique o ID digitado.");
            }
        }

        public void ExcluirProduto()
        {
            ListarProduto();

            Console.WriteLine("Digite o id do produto que deseja excluir");

            int id = int.Parse(Console.ReadLine());

            Produto p = NProduto.Listar(id); // Retrieve the product with the specified ID

            if (p != null)
            {
                NProduto.Excluir(p); // Call the method to delete the product
                Console.WriteLine("Produto excluído com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado. Verifique o ID digitado.");
            }
        }

        //==========================MAQUINA ==========================
        public void ListarMaquina()
        {
            // Listando as máquinas
            var maquinas = NMaquina.Listar();
            Console.WriteLine($"Máquinas:");
            Console.WriteLine($"\n");
            foreach (var maquina in maquinas)
            {
                Console.WriteLine($"{maquina.Id} - {maquina.Local}");
            }
            Console.WriteLine($"\n");
        }

        public void CadastrarMaquina()
        {
            // inserir maquina no sistema
            Console.WriteLine("Inserção de máquina no sistema");
            Console.Write("Informe a localização da máquina: ");
            string local = Console.ReadLine();
            // Verificando o ID da última máquina na lista de máquinas
            int ultimoId = 0;
            List<Maquina> maquinas = NMaquina.Listar();
            foreach (Maquina maquina in maquinas)
            {
                if (maquina.Id > ultimoId)
                {
                    ultimoId = maquina.Id;
                }
            }
            // Incrementando o ID para criar o novo ID da máquina
            int novoId = ultimoId + 1;

            Maquina m = new Maquina(local, novoId); //?
            NMaquina.Inserir(m);
            Console.WriteLine("Máquina inserida com sucesso!");
        }

        public void AtualizarMaquina()
        {
            ListarMaquina();

            Console.WriteLine("Digite o id da máquina que deseja atualizar");

            int id = int.Parse(Console.ReadLine());

            Maquina m = NMaquina.Listar(id);

            if (m != null)
            {
                Console.Write("Informe o novo local da Maquina: ");
                string n = Console.ReadLine();

                m.Local = n;

                NMaquina.Atualizar(m);
                Console.WriteLine("Maquina atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Maquina não encontrado. Verifique o ID digitado.");
            }
        }

        public void ExcluirMaquina()
        {
            ListarMaquina();

            Console.WriteLine("Digite o id da máquina que deseja excluir");

            int id = int.Parse(Console.ReadLine());

            Maquina m = NMaquina.Listar(id);

            if (m != null)
            {
                NMaquina.Excluir(m);
                Console.WriteLine("Máquina excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("Máquina não encontrada. Verifique o ID digitado.");
            }
        }

        public void AbastecerMaquina()
        {
            ListarMaquina();
            Console.WriteLine("Digite o id da máquina que deseja abastecer");
            int idMaquina = int.Parse(Console.ReadLine());

            Maquina maquina = NMaquina.Listar(idMaquina);

            if (maquina != null)
            {
                Console.WriteLine($"Máquina selecionado: {maquina}");
                Console.WriteLine("Produtos disponíveis para abastecimento: ");

                ListarProduto();

                Console.WriteLine("Digite o id do produto que deseja abastecer");
                int idProduto = int.Parse(Console.ReadLine());

                Console.WriteLine("Quantidade");
                int quantidadeAbastecimento = int.Parse(Console.ReadLine());

                Produto produto = NProduto.Listar(idProduto);
                if (produto != null)
                {
                    Console.WriteLine(
                        $"Produto selecionado: {produto.Nome} - R${produto.Valor:F2}"
                    );

                    // Encontra o estoque do produto na máquina (se existir)
                    EstoqueProduto estoqueProdutoMaquina = NEstoqueProduto.ListarPorMaquinaEProduto(
                        maquina.Id,
                        idProduto
                    );

                    if (estoqueProdutoMaquina == null)
                    {
                        // Se não encontrou, cria uma nova entrada no estoque da máquina
                        estoqueProdutoMaquina = new EstoqueProduto(
                            0,
                            maquina.Id,
                            idProduto,
                            0,
                            100
                        );
                        NEstoqueProduto.Inserir(estoqueProdutoMaquina);
                        Console.WriteLine("Entrou no if 1");

                        EstoqueProduto estoqueGeral2 = NEstoqueProduto.ListarPorMaquinaEProduto(
                            idMaquina,
                            idProduto
                        );

                        if (estoqueGeral2 == null)
                        {
                            // Se não encontrou, cria uma nova entrada no estoque geral
                            estoqueGeral2 = new EstoqueProduto(0, idMaquina, idProduto, 0, 100);
                            NEstoqueProduto.Inserir(estoqueGeral2);

                            Console.WriteLine("Entrou no if 3");
                        }
                        else
                        {
                            // Se encontrou, atualiza a quantidade do produto no estoque geral
                            estoqueGeral2.QuantidadeEstoque += quantidadeAbastecimento;
                            NEstoqueProduto.Atualizar(estoqueGeral2);

                            Console.WriteLine("Entrou no if 4");
                        }
                    }
                    else
                    {
                        // Se encontrou, atualiza a quantidade do produto no estoque da máquina
                        estoqueProdutoMaquina.QuantidadeEstoque += quantidadeAbastecimento;
                        NEstoqueProduto.Atualizar(estoqueProdutoMaquina);

                        Console.WriteLine("Entrou no if 2");
                    }

                    // Atualiza o estoque do produto geral
                    EstoqueProduto estoqueGeral = NEstoqueProduto.Listar(idProduto);

                    if (estoqueGeral == null)
                    {
                        // Se não encontrou, cria uma nova entrada no estoque geral
                        estoqueGeral = new EstoqueProduto(0, idMaquina, idProduto, 0, 100);
                        NEstoqueProduto.Inserir(estoqueGeral);

                        Console.WriteLine("Entrou no if 3");
                    }

                    produto.Quantidade -= quantidadeAbastecimento;
                    NProduto.Atualizar(produto);

                    Console.WriteLine("Abastecimento realizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado. Verifique o ID digitado.");
                }
            }
            else
            {
                Console.WriteLine("Maquina não encontrada. Verifique o ID digitado.");
            }

            ExibirVitrine(maquina);
        }

        //==========================OUTROS ==========================

        public void EscolherMaquina()
        {
            // Listando as máquinas
            var maquinas = NMaquina.Listar();
            int cont = 0;
            foreach (var m in maquinas)
            {
                Console.WriteLine($"{m.Id} - {m.Local}");
                cont++;
            }
            // Escolhendo a máquina pelo id
            if (cont != 0)
            {
                Console.Write("Digite o ID da máquina desejada: ");
                int idMaquina = int.Parse(Console.ReadLine());

                Maquina maquina = NMaquina.Listar(idMaquina);

                if (idMaquina != null)
                {
                    ExibirVitrineVisitante(maquina);
                }
                else
                {
                    Console.WriteLine("Máquina não encontrada.");
                }
            }
            else
            {
                Console.WriteLine("No momento, não existem máquinas cadastradas :(");
            }
        }

        public void ExibirVitrineVisitante(Maquina maquina)
        {
            Console.WriteLine($"Vitrine da Máquina - {maquina.Local}");
            List<EstoqueProduto> estoqueDaMaquina = NEstoqueProduto.ListarPorMaquina(maquina.Id);

            if (estoqueDaMaquina.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado nesta máquina.");
            }
            else
            {
                Console.WriteLine("Produtos disponíveis na máquina:");
                foreach (var estoqueProduto in estoqueDaMaquina)
                {
                    Produto produto = NProduto.Listar(estoqueProduto.IdProduto);
                    Console.WriteLine(
                        $"{produto.Id} - {produto.Nome} - R${produto.Valor:F2} - Quantidade: {estoqueProduto.QuantidadeEstoque}"
                    );
                }
            }

            EscolherProduto(maquina);
        }

        public void ExibirVitrine(Maquina maquina)
        {
            Console.WriteLine($"Vitrine da Máquina - {maquina.Local}");
            List<EstoqueProduto> estoqueDaMaquina = NEstoqueProduto.ListarPorMaquina(maquina.Id);

            if (estoqueDaMaquina.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado nesta máquina.");
            }
            else
            {
                Console.WriteLine("Produtos disponíveis na máquina:");
                foreach (var estoqueProduto in estoqueDaMaquina)
                {
                    Produto produto = NProduto.Listar(estoqueProduto.IdProduto);
                    Console.WriteLine(
                        $"{produto.Id} - {produto.Nome} - R${produto.Valor:F2} - Quantidade: {estoqueProduto.QuantidadeEstoque}"
                    );
                }
            }
        }

        public void EscolherProduto(Maquina maquina)
        {
            Console.WriteLine("Digite o id do produto que deseja comprar");
            int idProduto = int.Parse(Console.ReadLine());

            EstoqueProduto produto = NEstoqueProduto.ListarPorMaquinaEProduto(
                maquina.Id,
                idProduto
            );
            Produto prod = NProduto.Listar(idProduto);
            Console.WriteLine($"{produto.QuantidadeEstoque}");

            if (produto != null)
            {
                if (produto.QuantidadeEstoque > 0)
                {
                    VerificarPagamento(maquina, prod);
                }
                else
                {
                    Console.WriteLine("Produto indisponível na maquina");
                }
            }
            else
            {
                Console.WriteLine("Produto nao encontrado, verifique se o Id está correto");
            }
        }

        public void VerificarPagamento(Maquina maquina, Produto produto)
        {
            Console.WriteLine($"O valor do produto é R${produto.Valor:F2}");

            Console.WriteLine($"Insira o pagamento do produto");
            double valorP = double.Parse(Console.ReadLine());

            if (valorP < produto.Valor)
            {
                Console.WriteLine($"O valor inserido é insuficiente para efetuação da compra. :(");
            }
            else if (valorP == produto.Valor)
            {
                Console.WriteLine($"Compra bem sucedida. Voce recebeu seu produto: {produto.Nome}");
                // Subtrai 1 da quantidade do produto no estoque da máquina
                EstoqueProduto estoqueProdutoMaquina = NEstoqueProduto.ListarPorMaquinaEProduto(
                    maquina.Id,
                    produto.Id
                );
                if (estoqueProdutoMaquina != null)
                {
                    estoqueProdutoMaquina.QuantidadeEstoque -= 1;
                    NEstoqueProduto.Atualizar(estoqueProdutoMaquina);
                }
                else
                {
                    Console.WriteLine("Erro ao atualizar o estoque da máquina.");
                }
            }
            else
            {
                Console.WriteLine($"Compra bem sucedida. Voce recebeu seu produto: {produto.Nome}");
                double troco = valorP - produto.Valor;
                Console.WriteLine($"Seu troco é de: R${troco:F2}");
                // Subtrai 1 da quantidade do produto no estoque da máquina
                EstoqueProduto estoqueProdutoMaquina = NEstoqueProduto.ListarPorMaquinaEProduto(
                    maquina.Id,
                    produto.Id
                );
                if (estoqueProdutoMaquina != null)
                {
                    estoqueProdutoMaquina.QuantidadeEstoque -= 1;
                    NEstoqueProduto.Atualizar(estoqueProdutoMaquina);
                }
                else
                {
                    Console.WriteLine("Erro ao atualizar o estoque da máquina.");
                }
            }
        }

        public void SairSistema()
        {
            Console.WriteLine("Saindo do sistema...");
            Environment.Exit(0);
        }
    }
}
