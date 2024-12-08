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
                Console.WriteLine("7. Mostrar historico de operações");
                Console.WriteLine("8. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = LerString();
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
                        Operacao.ListarHistorico();
                        break;
                    case "8":
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

                string opcao = LerString();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Tipo: Pessoa Física ou Pessoa Jurídica");
                        string tipo = LerString();
                        Console.WriteLine("Cadastro: CPF ou CNPJ");
                        string cadastro = LerString();
                        Console.WriteLine("Nome: ");
                        string nome = LerString();
                        Operador.Insert(new Operador(tipo, cadastro, nome));
                        Console.WriteLine("Operador adicionado com sucesso!");
                        break;

                    case "2":
                        Operador.List();
                        break;

                    case "3":
                        Console.WriteLine("Digite o ID do operador para atualizar: ");
                        int idOperador = LerInteiro();
                        Console.WriteLine("Novo Tipo: ");
                        tipo = LerString();
                        Console.WriteLine("Novo Cadastro: ");
                        cadastro = LerString();
                        Console.WriteLine("Novo Nome: ");
                        nome = LerString();
                        Operador.Update(idOperador, new Operador(tipo, cadastro, nome));
                        Console.WriteLine("Operador atualizado com sucesso!");
                        break;

                    case "4":
                        Console.WriteLine("Digite o ID do operador para deletar: ");
                        idOperador = LerInteiro();
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

                string opcao = LerString();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Nome do Modelo: ");
                        string nomeModelo = LerString();
                        Console.WriteLine("Peso de Decolagem: ");
                        float peso = LerFloat();
                        Modelo.Insert(new Modelo(nomeModelo, peso));
                        Console.WriteLine("Modelo adicionado com sucesso!");
                        break;

                    case "2":
                        Modelo.List();
                        break;

                    case "3":
                        Console.WriteLine("Digite o ID do modelo para atualizar: ");
                        int idModelo = LerInteiro();
                        Console.WriteLine("Novo Nome do Modelo: ");
                        nomeModelo = LerString();
                        Console.WriteLine("Novo Peso de Decolagem: ");
                        peso = LerFloat();
                        Modelo.Update(idModelo, new Modelo(nomeModelo, peso));
                        Console.WriteLine("Modelo atualizado com sucesso!");
                        break;

                    case "4":
                        Console.WriteLine("Digite o ID do modelo para deletar: ");
                        idModelo = LerInteiro();
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

                string opcao = LerString();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Nome do Fabricante: ");
                        string nomeFabricante = LerString();
                        Fabricante.Insert(new Fabricante(nomeFabricante));
                        Console.WriteLine("Fabricante adicionado com sucesso!");
                        break;

                    case "2":
                        Fabricante.List();
                        break;

                    case "3":
                        Console.WriteLine("Digite o ID do fabricante para atualizar: ");
                        int idFabricante = LerInteiro();
                        Console.WriteLine("Novo Nome do Fabricante: ");
                        nomeFabricante = LerString();
                        Fabricante.Update(idFabricante, new Fabricante(nomeFabricante));
                        Console.WriteLine("Fabricante atualizado com sucesso!");
                        break;

                    case "4":
                        Console.WriteLine("Digite o ID do fabricante para deletar: ");
                        idFabricante = LerInteiro();
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

                string opcao = LerString();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("Código da Aeronave: ");
                        string codigo = LerString();
                        Console.WriteLine("Número de Série: ");
                        string numeroSerie = LerString();
                        Console.WriteLine("ID do Modelo: ");
                        int modeloId = LerInteiro();
                        Console.WriteLine("ID do Fabricante: ");
                        int fabricanteId = LerInteiro();
                        Aeronave.Insert(new Aeronave(codigo, numeroSerie, modeloId, fabricanteId));
                        Console.WriteLine("Aeronave adicionada com sucesso!");
                        break;

                    case "2":
                        Aeronave.List();
                        break;

                    case "3":
                        Console.WriteLine("Digite o ID da aeronave para atualizar: ");
                        int idAeronave = LerInteiro();
                        Console.WriteLine("Novo Código da Aeronave: ");
                        codigo = LerString();
                        Console.WriteLine("Novo Número de Série: ");
                        numeroSerie = LerString();
                        Console.WriteLine("Novo ID do Modelo: ");
                        modeloId = LerInteiro();
                        Console.WriteLine("Novo ID do Fabricante: ");
                        fabricanteId = LerInteiro();
                        Aeronave.Update(idAeronave, new Aeronave(codigo, numeroSerie, modeloId, fabricanteId));
                        Console.WriteLine("Aeronave atualizada com sucesso!");
                        break;

                    case "4":
                        Console.WriteLine("Digite o ID da aeronave para deletar: ");
                        idAeronave = LerInteiro();
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

        private static void AddOperacao()
        {
            Console.WriteLine("ID do Operador: ");
            int operadorId = LerInteiro();
            Console.WriteLine("ID da Aeronave: ");
            int aeronaveId = LerInteiro();
            Console.WriteLine("Ramo de Atividade: ");
            string ramo = LerString();
            Console.WriteLine("Tipo de Uso: ");
            string tipoUso = LerString();

            DateOnly data = DateOnly.MinValue;
            bool isValidDate = false;

            while (!isValidDate)
            {
                Console.WriteLine("Data de Validade (dd-MM-yyyy): ");
                string inputData = LerString();

                isValidDate = DateOnly.TryParseExact(inputData, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out data);

                if (!isValidDate)
                {
                    Console.WriteLine("Data inválida. Por favor, insira a data no formato dd-MM-yyyy.");
                }
            }

            Operacao.Insert(new Operacao(operadorId, aeronaveId, ramo, data, tipoUso));
            Console.WriteLine("Operação adicionada com sucesso!");
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

                string opcao = LerString();

                switch (opcao)
                {
                    case "1":
                        AddOperacao();
                        break;

                    case "2":
                        Operacao.List();
                        break;

                    case "3":
                        Console.WriteLine("Digite o ID do Operador da operação que deseja atualizar: ");
                        int operadorId = LerInteiro();
                        Console.WriteLine("Digite o ID da Aeronave da operação que deseja atualizar: ");
                        int aeronaveId = LerInteiro();
                        Console.WriteLine("Novo Ramo de Atividade: ");
                        string ramo = LerString();
                        Console.WriteLine("Novo Tipo de Uso: ");
                        string tipoUso = LerString();
                        Console.WriteLine("Nova Data de Validade (dd-MM-yyyy): ");
                        DateOnly data = DateOnly.ParseExact(LerString(), "dd-MM-yyyy", null);
                        Operacao.Update(aeronaveId, operadorId, new Operacao(operadorId, aeronaveId, ramo, data, tipoUso));
                        Console.WriteLine("Operação atualizada com sucesso!");
                        break;

                    case "4":
                        Console.WriteLine("Digite o ID do operador da operação que deseja deletar: ");
                        operadorId = LerInteiro();
                        Console.WriteLine("Digite o ID da aeronave da operação que deseja deletar: ");
                        aeronaveId = LerInteiro();
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

        private static int LerInteiro()
        {
            int resultado;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out resultado))
                {
                    return resultado;
                }
                Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro.");
            }
        }

        private static string LerString()
        {
            return Console.ReadLine();
        }

        private static float LerFloat()
        {
            float resultado;
            while (true)
            {
                if (float.TryParse(Console.ReadLine(), out resultado))
                {
                    return resultado;
                }
                Console.WriteLine("Entrada inválida. Por favor, insira um número decimal.");
            }
        }
    }
}
