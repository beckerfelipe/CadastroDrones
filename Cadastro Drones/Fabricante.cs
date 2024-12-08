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
        public string Nome { get; set; }

        public Fabricante(string nome)
        {
            Nome = nome;
        }

        public static void Insert(Fabricante fabricante)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "INSERT INTO Fabricante (Nome_fabricante) VALUES (@Nome)";
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
                string query = "UPDATE Fabricante SET Nome = @Nome WHERE fabricante_id = @fabricanteId";
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

        public static void Delete(int Id)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "DELETE FROM Fabricante WHERE Fabricante_Id = @fabricanteId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@fabricanteId", Id);
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
                string query = "SELECT * FROM Fabricante";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                MySqlDataReader reader = command.ExecuteReader();

                Console.WriteLine(new string('-', 45));
                Console.WriteLine("{0,22}", "FABRICANTE");
                Console.WriteLine(new string('-', 45));
                Console.WriteLine("{0,-15} {1,-30}", "Fabricante_Id", "Nome_fabricante");
                Console.WriteLine(new string('-', 45));

                while (reader.Read())
                {
                    Console.WriteLine("{0,-15} {1,-30}",
                        reader["fabricante_Id"],
                        reader["Nome_fabricante"]);
                }
                Console.WriteLine("");

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
