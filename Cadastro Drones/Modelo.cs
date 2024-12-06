using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_Drones
{
    internal class Modelo
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Modelo(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static void Insert(Modelo modelo)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "INSERT INTO Modelo (Nome) VALUES (@Nome)";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Nome", modelo.Nome);

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

        public static void Update(int modeloId, Modelo modelo)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "UPDATE Modelo SET Nome = @Nome WHERE Id = @modeloId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Nome", modelo.Nome);
                command.Parameters.AddWithValue("@Id", modeloId);

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

        public static void Delete(int modeloId)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "DELETE FROM Modelo WHERE Id = @modeloId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Id", modeloId);

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
    }
}