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
        public string Nome { get; set; }
        public float Peso { get; set; }

        public Modelo(string nome, float peso)
        {
            Nome = nome;
            Peso = peso;
        }

        public static void Insert(Modelo modelo)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "INSERT INTO Modelo (Nome_modelo, peso_decolagem) VALUES (@Nome,@Peso)";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Nome", modelo.Nome);
                command.Parameters.AddWithValue("@Peso", modelo.Peso);

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

        public static void Delete(int Id)
        {
            try
            {
                DatabaseConnection.Connection.Open();
                string query = "DELETE FROM Modelo WHERE Id = @modeloId";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                command.Parameters.AddWithValue("@Id", Id);

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
                string query = "SELECT * FROM Modelo";
                MySqlCommand command = new MySqlCommand(query, DatabaseConnection.Connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["modelo_Id"] + " - " + reader["Nome_modelo"] + " - " + reader["Peso_decolagem"]);
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