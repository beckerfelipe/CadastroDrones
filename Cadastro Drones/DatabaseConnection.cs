using System;
using MySql.Data.MySqlClient; // Use MySql.Data.MySqlClient para MySQL

namespace Cadastro_Drones
{
    public static class DatabaseConnection
    {
        private static readonly string connectionString = "server=localhost;user=root;password=root;database=mydb";

        private static MySqlConnection connection;

        private static MySqlCommand command;

        public static MySqlConnection Connection
        {
            get
            {
                return connection;
            }
        }

        public static void Start()
        {
            connection = new MySqlConnection(connectionString);
            connection.Open();

            InitDatabase();

            connection.Close();

            Console.WriteLine("Database initialized");
            Console.WriteLine(DatabaseConnection.Connection.State);

            InserirOperadores();
            InserirModelos();
            InserirFabricantes();
            InserirAeronaves();
            InserirOperacoes();
        }

        public static void ResetDatabase()
        {
            command = new MySqlCommand(
             @"
            DROP TABLE IF EXISTS `Operacao`;
            DROP TABLE IF EXISTS `HISTORICO_OPERACOES`;
            DROP TABLE IF EXISTS `Aeronave`;
            DROP TABLE IF EXISTS `Operador`;
            DROP TABLE IF EXISTS `Fabricante`;
            DROP TABLE IF EXISTS `Modelo`;
            ", connection);

            command.ExecuteNonQuery();
        }

        public static void InitDatabase()
        {
            ResetDatabase();

            command = new MySqlCommand("CREATE DATABASE IF NOT EXISTS mydb", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand("USE mydb", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand(
                "CREATE TABLE IF NOT EXISTS `Modelo` (" +
                "`Modelo_Id` INT NOT NULL AUTO_INCREMENT, " +
                "`nome_modelo` VARCHAR(45) NOT NULL, " +
                "`peso_decolagem` FLOAT NOT NULL, " +
                "PRIMARY KEY (`Modelo_Id`))", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand(
                "CREATE TABLE IF NOT EXISTS `Fabricante` (" +
                "`Fabricante_Id` INT NOT NULL AUTO_INCREMENT, " +
                "`nome_fabricante` VARCHAR(45) NOT NULL, " +
                "PRIMARY KEY (`Fabricante_Id`))", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand(
                "CREATE TABLE IF NOT EXISTS `Aeronave` (" +
                "`Aeronave_Id` INT NOT NULL AUTO_INCREMENT, " +
                "`codigo_aeronave` VARCHAR(20) NOT NULL, " +
                "`numero_serie` VARCHAR(45) NOT NULL, " +
                "`Modelo_id` INT NOT NULL, " +
                "`Fabricante_id` INT NOT NULL, " +
                "PRIMARY KEY (`Aeronave_Id`), " +
                "FOREIGN KEY (`Modelo_id`) " +
                "REFERENCES `Modelo` (`Modelo_Id`) " +
                "ON DELETE CASCADE, " +
                "FOREIGN KEY (`Fabricante_id`) " +
                "REFERENCES `Fabricante` (`Fabricante_Id`) " +
                "ON DELETE CASCADE)", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand(
                "CREATE TABLE IF NOT EXISTS `Operador` (" +
                "`Operador_Id` INT NOT NULL AUTO_INCREMENT, " +
                "`tipo` VARCHAR(20) NOT NULL, " +
                "`cadastro` VARCHAR(20) NOT NULL, " +
                "`nome_operador` VARCHAR(45) NOT NULL, " +
                "PRIMARY KEY (`Operador_Id`))", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand(
                "CREATE TABLE IF NOT EXISTS `Operacao` (" +
                "`Operador_Id` INT NOT NULL, " +
                "`Aeronave_Id` INT NOT NULL, " +
                "`ramo_atividade` VARCHAR(100) NOT NULL, " +
                "`tipo_uso` VARCHAR(100) NOT NULL, " +
                "`data_validade` DATE NOT NULL, " +
                "PRIMARY KEY (`Operador_Id`, `Aeronave_Id`), " +
                "FOREIGN KEY (`Aeronave_Id`) " +
                "REFERENCES `Aeronave` (`Aeronave_Id`) " +
                "ON DELETE CASCADE, " +
                "FOREIGN KEY (`Operador_Id`) " +
                "REFERENCES `Operador` (`Operador_Id`) " +
                "ON DELETE CASCADE)", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand(@"
                CREATE TABLE IF NOT EXISTS HISTORICO_OPERACOES (
                    Historico_Id INT NOT NULL AUTO_INCREMENT,  
                    Operador_Id INT NOT NULL,  
                    Aeronave_Id INT NOT NULL,  
                    ramo_atividade VARCHAR(100) NOT NULL,  
                    tipo_uso VARCHAR(100) NOT NULL,  
                    data_validade DATE NOT NULL,  
                    PRIMARY KEY (Historico_Id)
                );", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand("CREATE OR REPLACE VIEW `Todas_Operacoes` AS " +
                "SELECT op.Operador_Id, " +
                "op.Aeronave_Id, " +
                "op.ramo_atividade, " +
                "op.tipo_uso, " +
                "op.data_validade, " +
                "o.nome_operador, " +
                "a.codigo_aeronave, " +
                "a.numero_serie, " +
                "m.nome_modelo, " +
                "f.nome_fabricante " +
                "FROM `Operacao` op " +
                "INNER JOIN `Operador` o ON op.Operador_Id = o.Operador_Id " +
                "INNER JOIN `Aeronave` a ON op.Aeronave_Id = a.Aeronave_Id " +
                "INNER JOIN `Modelo` m ON a.Modelo_id = m.Modelo_Id " +
                "INNER JOIN `Fabricante` f ON a.Fabricante_id = f.Fabricante_Id", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand(
              "CREATE TRIGGER `INSERE_HISTORICO_OPERACOES` " +
              "AFTER INSERT ON `Operacao` " +
              "FOR EACH ROW " +
              "INSERT INTO `HISTORICO_OPERACOES` " +
              "(`Operador_Id`, `Aeronave_Id`, `ramo_atividade`, `tipo_uso`, `data_validade`) " +
              "VALUES (NEW.Operador_Id, NEW.Aeronave_Id, NEW.ramo_atividade, NEW.tipo_uso, NEW.data_validade)",
            connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand(
                "CREATE TRIGGER `UPDATE_HISTORICO_OPERACOES` " +
                "AFTER UPDATE ON `Operacao` " +
                "FOR EACH ROW " +
                "INSERT INTO `HISTORICO_OPERACOES` " +
                "(`Operador_Id`, `Aeronave_Id`, `ramo_atividade`, `tipo_uso`, `data_validade`) " +
                "VALUES (NEW.Operador_Id, NEW.Aeronave_Id, NEW.ramo_atividade, NEW.tipo_uso, NEW.data_validade)",
              connection);
            command.ExecuteNonQuery();
        }

        static void InserirOperadores()
        {
            Operador operador = new Operador("Pessoa Física", "123456789", "João");
            Operador.Insert(operador);

            operador = new Operador("Pessoa Jurídica", "987654321", "Empresa");
            Operador.Insert(operador);

            operador = new Operador("Pessoa Física", "123456789", "Maria");
            Operador.Insert(operador);

            Console.WriteLine("Operadores inseridos");
        }

        static void InserirModelos()
        {
            Modelo modelo = new Modelo("Modelo 1", 1.0f);
            Modelo.Insert(modelo);

            modelo = new Modelo("Modelo 2", 1.5f);
            Modelo.Insert(modelo);

            modelo = new Modelo("Modelo 3", 1.75f);
            Modelo.Insert(modelo);

            Console.WriteLine("Modelos inseridos");
        }

        static void InserirFabricantes()
        {
            Fabricante fabricante = new Fabricante("DJI");
            Fabricante.Insert(fabricante);

            fabricante = new Fabricante("XMOBOTS");
            Fabricante.Insert(fabricante);

            fabricante = new Fabricante("Robson");
            Fabricante.Insert(fabricante);

            Console.WriteLine("Fabricantes inseridos");
        }

        static void InserirAeronaves()
        {
            Aeronave aeronave = new Aeronave("PP-11082012", "08QCE7C0120QNU", 1, 1);
            Aeronave.Insert(aeronave);

            aeronave = new Aeronave("PP-26534803", "163dG6G00170Y0", 2, 2);
            Aeronave.Insert(aeronave);

            aeronave = new Aeronave("PP-35041299", "3YTBJAB", 3, 3);
            Aeronave.Insert(aeronave);

            Console.WriteLine("Aeronaves inseridas");
        }

        static void InserirOperacoes()
        {
            Operacao operacao = new Operacao(1, 1, "Aerofotografia", DateOnly.Parse("2024-12-15"), "Básico");
            Operacao.Insert(operacao);

            operacao = new Operacao(2, 2, "Aerocinematografia", DateOnly.Parse("2024-12-16"), "Básico");
            Operacao.Insert(operacao);

            operacao = new Operacao(3, 3, "Recreativo", DateOnly.Parse("2024-12-17"), "Básico");
            Operacao.Insert(operacao);

            Console.WriteLine("Operações inseridas");
        }
    }
}
