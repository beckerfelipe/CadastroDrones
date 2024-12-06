using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using MySql.Data.MySqlClient; // Use MySql.Data.MySqlClient para MySQL

namespace Cadastro_Drones
{
    public static class DatabaseConnection
    {
        private static readonly string connectionString = "";

        private static MySqlConnection connection;

        private static MySqlCommand command;

        public static MySqlConnection Connection
        {
            get
            {
                return connection;
            }
        }

        private static void InitDatabase()
        {
            command = new MySqlCommand("CREATE DATABASE IF NOT EXISTS myDatabase", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand("USE myDatabase", connection);
            command.ExecuteNonQuery();

            command = new MySqlCommand("CREATE TABLE IF NOT EXISTS Fabricante (id )");
        }

        public static void Start()
        {

            connection = new MySqlConnection(connectionString);
            connection.Open();

            InitDatabase();

        }
    }
}
