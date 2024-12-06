using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_Drones
{
    internal class Operador
    {
        public int Id { get; private set; }
        public string Tipo { get; private set; }
        public string Cadastro { get; private set; }
        public string Nome { get; private set; }
    
        public Operador(int id, string tipo, string cadastro, string nome)
        {
            Id = id;
            Tipo = tipo;
            Cadastro = cadastro;
            Nome = nome;
        }

        public static void Insert(Operador operador)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query= "INSERT INTO Operador (Tipo, Cadastro, Nome) VALUES (@Tipo, @Cadastro, @Nome)";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Tipo", operador.Tipo);
                command.Parameters.AddWithValue("@Cadastro", operador.Cadastro);
                command.Parameters.AddWithValue("@Nome", operador.Nome);

                command.ExecuteNonQuery();
            }
            catch(MySqlException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                DatabaseConnection.Connection.Close();
            }
        }

        public static void Update(int operadorId, Operador operador)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "UPDATE Operador SET Tipo = @Tipo, Cadastro = @Cadastro, Nome = @Nome WHERE Id = @operadorId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Tipo", operador.Tipo);
                command.Parameters.AddWithValue("@Cadastro", operador.Cadastro);
                command.Parameters.AddWithValue("@Nome", operador.Nome);
                command.Parameters.AddWithValue("@Id", operadorId);

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                DatabaseConnection.Connection.Close();
            }
        }

        public static void Delete(Operador operador)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "DELETE FROM Operador WHERE Id = @Id";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Id", operador.Id);

                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                DatabaseConnection.Connection.Close();
            }
        }

        public static void List()
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "SELECT * FROM Operador";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Id"] + " - " + reader["Tipo"] + " - " + reader["Cadastro"] + " - " + reader["Nome"]);
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            finally
            {
                DatabaseConnection.Connection.Close();
            }
        }
    }
}
