using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_Drones
{
    internal class Fabricante
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Fabricante(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public static void Insert(Fabricante fabricante)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "INSERT INTO Fabricante (Nome) VALUES (@Nome)";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Nome", fabricante.Nome);

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
        public static void Update(int fabricanteId, Fabricante fabricante)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "UPDATE Fabricante SET Nome = @Nome WHERE Id = @fabricanteId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Nome", fabricante.Nome);
                command.Parameters.AddWithValue("@Id", fabricanteId);

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

        public static void Delete(int fabricanteId)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "DELETE FROM Fabricante WHERE Id = @fabricanteId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Id", fabricanteId);

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
