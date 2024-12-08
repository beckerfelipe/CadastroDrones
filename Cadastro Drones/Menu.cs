using System;

namespace Cadastro_Drones
{
    internal class Menu
    {
        public static void MostrarMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("===== MENU =====");
                Console.WriteLine("1. Gerenciar Operadores");
                Console.WriteLine("2. Gerenciar Modelos");
                Console.WriteLine("3. Gerenciar Fabricantes");
                Console.WriteLine("4. Gerenciar Aeronaves");
                Console.WriteLine("5. Gerenciar Operações");
                Console.WriteLine("6. Mostrar todas tabelas");
                Console.WriteLine("7. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        MenuOperadores();
                        break;
                    case "2":
                        MenuModelos();
                        break;
                    case "3":
                        MenuFabricantes();
                        break;
                    case "4":
                        MenuAeronaves();
                        break;
                    case "5":
                        MenuOperacoes();
                        break;
                    case "6":
                        Fabricante.List();
                        Modelo.List();
                        Aeronave.List();
                        Operador.List();
                        Operacao.List();
                        break;
                    case "7":
                        exit = true;
                        return;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private static void MenuOperadores()
        {
            while (true)
            {
                Console.WriteLine("\n===== Gerenciar Operadores =====");
                Console.WriteLine("1. Adicionar Operador");
                Console.WriteLine("2. Listar Operadores");
                Console.WriteLine("3. Atualizar Operador");
                Console.WriteLine("4. Deletar Operador");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Tipo: Pessoa Física ou Pessoa Jurídica");
                        string tipo = Console.ReadLine();
                        Console.Write("Cadastro: CPF ou CNPJ");
                        string cadastro = Console.ReadLine();
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Operador.Insert(new Operador(tipo, cadastro, nome));
                        Console.WriteLine("Operador adicionado com sucesso!");
                        break;

                    case "2":
                        Operador.List();
                        break;

                    case "3":
                        Console.Write("Digite o ID do operador para atualizar: ");
                        int idOperador = int.Parse(Console.ReadLine());
                        Console.Write("Novo Tipo: ");
                        tipo = Console.ReadLine();
                        Console.Write("Novo Cadastro: ");
                        cadastro = Console.ReadLine();
                        Console.Write("Novo Nome: ");
                        nome = Console.ReadLine();
                        Operador.Update(idOperador, new Operador(tipo, cadastro, nome));
                        Console.WriteLine("Operador atualizado com sucesso!");
                        break;

                    case "4":
                        Console.Write("Digite o ID do operador para deletar: ");
                        idOperador = int.Parse(Console.ReadLine());
                        Operador.Delete(idOperador);
                        Console.WriteLine("Operador deletado com sucesso!");
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private static void MenuModelos()
        {
            while (true)
            {
                Console.WriteLine("\n===== Gerenciar Modelos =====");
                Console.WriteLine("1. Adicionar Modelo");
                Console.WriteLine("2. Listar Modelos");
                Console.WriteLine("3. Atualizar Modelo");
                Console.WriteLine("4. Deletar Modelo");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Nome do Modelo: ");
                        string nomeModelo = Console.ReadLine();
                        Console.Write("Peso de Decolagem: ");
                        float peso = float.Parse(Console.ReadLine());
                        Modelo.Insert(new Modelo(nomeModelo, peso));
                        Console.WriteLine("Modelo adicionado com sucesso!");
                        break;

                    case "2":
                        Modelo.List();
                        break;

                    case "3":
                        Console.Write("Digite o ID do modelo para atualizar: ");
                        int idModelo = int.Parse(Console.ReadLine());
                        Console.Write("Novo Nome do Modelo: ");
                        nomeModelo = Console.ReadLine();
                        Console.Write("Novo Peso de Decolagem: ");
                        peso = float.Parse(Console.ReadLine());
                        Modelo.Update(idModelo, new Modelo(nomeModelo, peso));
                        Console.WriteLine("Modelo atualizado com sucesso!");
                        break;

                    case "4":
                        Console.Write("Digite o ID do modelo para deletar: ");
                        idModelo = int.Parse(Console.ReadLine());
                        Modelo.Delete(idModelo);
                        Console.WriteLine("Modelo deletado com sucesso!");
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private static void MenuFabricantes()
        {
            while (true)
            {
                Console.WriteLine("\n===== Gerenciar Fabricantes =====");
                Console.WriteLine("1. Adicionar Fabricante");
                Console.WriteLine("2. Listar Fabricantes");
                Console.WriteLine("3. Atualizar Fabricante");
                Console.WriteLine("4. Deletar Fabricante");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Nome do Fabricante: ");
                        string nomeFabricante = Console.ReadLine();
                        Fabricante.Insert(new Fabricante(nomeFabricante));
                        Console.WriteLine("Fabricante adicionado com sucesso!");
                        break;

                    case "2":
                        Fabricante.List();
                        break;

                    case "3":
                        Console.Write("Digite o ID do fabricante para atualizar: ");
                        int idFabricante = int.Parse(Console.ReadLine());
                        Console.Write("Novo Nome do Fabricante: ");
                        nomeFabricante = Console.ReadLine();
                        Fabricante.Update(idFabricante, new Fabricante(nomeFabricante));
                        Console.WriteLine("Fabricante atualizado com sucesso!");
                        break;

                    case "4":
                        Console.Write("Digite o ID do fabricante para deletar: ");
                        idFabricante = int.Parse(Console.ReadLine());
                        Fabricante.Delete(idFabricante);
                        Console.WriteLine("Fabricante deletado com sucesso!");
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private static void MenuAeronaves()
        {
            while (true)
            {
                Console.WriteLine("\n===== Gerenciar Aeronaves =====");
                Console.WriteLine("1. Adicionar Aeronave");
                Console.WriteLine("2. Listar Aeronaves");
                Console.WriteLine("3. Atualizar Aeronave");
                Console.WriteLine("4. Deletar Aeronave");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Código da Aeronave: ");
                        string codigo = Console.ReadLine();
                        Console.Write("Número de Série: ");
                        string numeroSerie = Console.ReadLine();
                        Console.Write("ID do Modelo: ");
                        int modeloId = int.Parse(Console.ReadLine());
                        Console.Write("ID do Fabricante: ");
                        int fabricanteId = int.Parse(Console.ReadLine());
                        Aeronave.Insert(new Aeronave(codigo, numeroSerie, modeloId, fabricanteId));
                        Console.WriteLine("Aeronave adicionada com sucesso!");
                        break;

                    case "2":
                        Aeronave.List();
                        break;

                    case "3":
                        Console.Write("Digite o ID da aeronave para atualizar: ");
                        int idAeronave = int.Parse(Console.ReadLine());
                        Console.Write("Novo Código da Aeronave: ");
                        codigo = Console.ReadLine();
                        Console.Write("Novo Número de Série: ");
                        numeroSerie = Console.ReadLine();
                        Console.Write("Novo ID do Modelo: ");
                        modeloId = int.Parse(Console.ReadLine());
                        Console.Write("Novo ID do Fabricante: ");
                        fabricanteId = int.Parse(Console.ReadLine());
                        Aeronave.Update(idAeronave, new Aeronave(codigo, numeroSerie, modeloId, fabricanteId));
                        Console.WriteLine("Aeronave atualizada com sucesso!");
                        break;

                    case "4":
                        Console.Write("Digite o ID da aeronave para deletar: ");
                        idAeronave = int.Parse(Console.ReadLine());
                        Aeronave.Delete(idAeronave);
                        Console.WriteLine("Aeronave deletada com sucesso!");
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private static void MenuOperacoes()
        {
            while (true)
            {
                Console.WriteLine("\n===== Gerenciar Operações =====");
                Console.WriteLine("1. Adicionar Operação");
                Console.WriteLine("2. Listar Operações");
                Console.WriteLine("3. Atualizar Operação");
                Console.WriteLine("4. Deletar Operação");
                Console.WriteLine("5. Voltar");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("ID do Operador: ");
                        int operadorId = int.Parse(Console.ReadLine());
                        Console.Write("ID da Aeronave: ");
                        int aeronaveId = int.Parse(Console.ReadLine());
                        Console.Write("Ramo de Atividade: ");
                        string ramo = Console.ReadLine();
                        Console.Write("Tipo de Uso: ");
                        string tipoUso = Console.ReadLine();
                        Console.Write("Data de Validade (dd-MM-yyyy): ");
                        DateOnly data = DateOnly.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null); // Mudança aqui
                        Operacao.Insert(new Operacao(operadorId, aeronaveId, ramo, data, tipoUso));
                        Console.WriteLine("Operação adicionada com sucesso!");
                        break;

                    case "2":
                        Operacao.List();
                        break;

                    case "3":
                        Console.Write("Digite o ID do Operador da operação que deseja atualizar: ");
                        operadorId = int.Parse(Console.ReadLine());
                        Console.Write("Digite o ID da Aeronave da operação que deseja atualizar: ");
                        aeronaveId = int.Parse(Console.ReadLine());
                        Console.Write("Novo Ramo de Atividade: ");
                        ramo = Console.ReadLine();
                        Console.Write("Novo Tipo de Uso: ");
                        tipoUso = Console.ReadLine();
                        Console.Write("Nova Data de Validade (dd-MM-yyyy): ");
                        data = DateOnly.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
                        Operacao.Update(aeronaveId, operadorId, new Operacao(operadorId, aeronaveId, ramo, data, tipoUso));
                        Console.WriteLine("Operação atualizada com sucesso!");
                        break;

                    case "4":
                        Console.Write("Digite o ID do operador da operação que deseja deletar: ");
                        operadorId = int.Parse(Console.ReadLine());
                        Console.Write("Digite o ID da aeronave da operação que deseja deletar: ");
                        aeronaveId = int.Parse(Console.ReadLine());
                        Operacao.Delete(aeronaveId, operadorId);
                        Console.WriteLine("Operação deletada com sucesso!");
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }
    }
}
